using System;
using System.Text;

namespace List
{
    public class ArrayList
    {
        private int[] _array;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if ((index < Length) && (index >= 0))
                {
                    return _array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if ((index < Length) && (index >= 0))
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }

        private ArrayList(int[] array)
        {
            Length = array.Length;

            _array = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public static ArrayList Create(int[] values)
        {
            if (!(values is null))
            {
                return new ArrayList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            ReSize();
            _array[Length] = value;
            Length++;
        }

        //добавление значения в начало
        public void AddToStart(int value)
        {
            ReSize();
            for (int i = Length - 1; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = value;

            ++Length;
        }

        //добавление значения по индексу

        public void AddValueByIndex(int value, int index)
        {
            if (index <= Length && index >= 0)
            {
                if (Length >= _array.Length)
                {
                    ReSize();
                }

                for (int i = Length - 1; i >= index; i--)
                {
                    _array[i + 1] = _array[i];
                }

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление из конца одного элемента

        public void RemoveElementFromEnd()
        {
            if (Length != 0)
            {
                Length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            ReSize();

        }

        //удаление из начала одного элемента
        public void RemoveElementFromStart()
        {
            for (int i = 1; i < Length; i++)
            {
                _array[i - 1] = _array[i];
            }

            ReSize();

            if (Length != 0)
            {
                Length--;
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление по индексу одного элемента
        public void RemoveElementByIndex(int index)
        {
            if (index < Length && index >= 0)
            {
                if (index == 0)
                {
                    RemoveElementFromStart();
                }
                //else if (index == Length - 1)
                //{
                //    RemoveElementFromStart();
                //}
                else
                {
                    Length--;

                    for (int i = index; i < Length; i++)
                    {
                        _array[i] = _array[i + 1];
                    }

                    ReSize();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        //удаление из конца N элементов
        public void RemoveNElementsFromEnd(int Nvalue)
        {
            if (Nvalue < Length)
            {
                if (!(Nvalue < 0))
                {
                    Length -= Nvalue;
                    ReSize();
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }

            else if (Nvalue == Length)
            {
                Length = 0;
                _array = new int[10];
            }

            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        //удаление из начала N элементов
        public void RemoveNElementsFromStart(int Nvalue)
        {
            if (Nvalue < Length)
            {
                if (!(Nvalue < 0))
                {
                    for (int i = Nvalue; i < Length; i++)
                    {
                        _array[i - Nvalue] = _array[i];
                    }

                    Length -= Nvalue;
                    ReSize();
                }

                else
                {
                    throw new ArgumentException("Invalid value");
                }
            }

            else if (Nvalue == Length)
            {
                Length = 0;
                _array = new int[10];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        //удаление по индексу N элементов
        public void RemoveNElementsByIndex(int Nvalue, int index)
        {
            if (index >= 0 && index < Length && Nvalue >= 0)
            {
                if (Nvalue + index > Length)
                {
                    Length = index;
                }
                else
                {
                    for (int i = index; i < Length; i++)
                    {
                        if (i + Nvalue < _array.Length)
                        {
                            _array[i] = _array[i + Nvalue];
                        }
                    }

                    Length -= Nvalue;
                }

                ReSize();
            }
            else if (Nvalue < 0)
            {
                throw new ArgumentException("Incorrect n");
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //первый индекс по значению
        public int SearchFirstIndexByValue(int value)
        {
            if (Length != 0)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i].CompareTo(value) == 0)
                    {
                        return i;
                    }
                }
            }

            return -1;

        }

        //реверс(123 -> 321)
        public void ReverseArray()
        {
            int temp;
            int swapIndex;

            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                temp = _array[i];

                _array[i] = _array[swapIndex];

                _array[swapIndex] = temp;
            }
        }

        //поиск индекс максимального элемента
        public int SearchIndexMaxElement()
        {
            if (!(Length == 0))
            {
                int maxIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[maxIndexOfElement] < _array[i])
                    {
                        maxIndexOfElement = i;
                    }
                }

                return maxIndexOfElement;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        //поиск индекс минимального элемента

        public int SearchIndexMinElement()
        {
            if (!(Length == 0))
            {

                int minIndexOfElement = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (_array[minIndexOfElement] > _array[i])
                    {
                        minIndexOfElement = i;
                    }
                }

                return minIndexOfElement;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        //поиск значения максимального элемента
        public int SearchValueMaxElement()
        {

            return _array[SearchIndexMaxElement()];
        }

        //поиск значения минимального элемента
        public int SearchValueMinElement()
        {
            return _array[SearchIndexMinElement()];

        }

        //сортировка по возрастанию
        public void SortAscending()//
        {
            int j;
            int temp;

            for (int i = 1; i < Length; i++)
            {
                j = i;
                temp = _array[i];

                while (j > 0 && temp < _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }

                _array[j] = temp;
            }
        }

        //сортировка по убыванию
        public void DescendingSort()
        {
            int j;
            int temp;

            for (int i = 1; i < Length; i++)
            {
                j = i;
                temp = _array[i];

                while (j > 0 && temp > _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }

                _array[j] = temp;
            }
        }

        //удаление по значению первого(?вернуть индекс)

        public void RemoveElementByValue(int value)
        {
            int index = SearchFirstIndexByValue(value);

            if (!(index == -1))
            {
                RemoveElementByIndex(index);
            }
        }

        //удаление по значению всех(?вернуть кол-во)

        public void RemoveAllElementsByValue(int value)
        {
            int indexOfElements = SearchFirstIndexByValue(value);

            while (indexOfElements != -1)
            {
                RemoveElementByIndex(indexOfElements);
                indexOfElements = SearchFirstIndexByValue(value);
            }
        }

        public void AddArrayList(ArrayList list)
        {
            if (list != null && list.Length != 0)
            {
                int lastIndex = Length;
                AddArrayListByIndex(list, lastIndex);
            }
        }

        //добавление списка в начало

        public void AddArrayListToStart(ArrayList list)
        {
            if (list != null && list.Length != 0)
            {
                int firstIndex = 0;
                AddArrayListByIndex(list, firstIndex);
            }
        }

        //добавление списка по индексу

        public void AddArrayListByIndex(ArrayList list, int index)
        {
            if (list != null && list.Length != 0)
            {
                if (index >= 0 && index <= Length)
                {
                    Length += list.Length;
                    if (Length >= _array.Length)
                    {
                        ReSize();
                    }

                    int tempLength = list.Length;
                    for (int i = Length - 1; i >= index; i--)
                    {
                        if (i + tempLength < _array.Length)
                        {
                            _array[i + tempLength] = _array[i];
                        }
                    }

                    int count = 0;
                    for (int i = index; i < Length; i++)
                    {
                        if (count < list.Length)
                        {
                            _array[i] = list[count++];
                        }
                    }
                }

                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            else
            {
                throw new ArgumentException("List no contains elements");
            }
        }

        private void ReSize()
        {
            if (Length >= _array.Length)
            {
                int newLenght = (int)(Length * 1.33 + 1);
                int[] tmpArray = new int[newLenght];

                for (int i = 0; i < _array.Length; i++)
                {
                    tmpArray[i] = _array[i];
                }

                _array = tmpArray;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException();
            }
            ArrayList list = (ArrayList)obj;
            if (this.Length != list.Length)
            {

                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != list._array[i])
                {
                    return false;
                }
            }

            return true;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                if (i == Length - 1)
                {
                    result.Append(_array[i]);
                }
                else
                {
                    result.Append(_array[i] + " ");
                }
            }

            return result.ToString();
        }
    }
}
