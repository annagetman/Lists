using System;

namespace List
{

    public class ArrayList
    {

        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 0;

            _array = new int[10];

            _array[0] = value;
        }

        public int this[int index]
        {
            get
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index > Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }


        public ArrayList(int[] values)
        {
            if (values != null)
            {
                Length = values.Length;
                _array = new int[(int)(values.Length * 2)];
                for (int i = 0; i < Length; i++)
                {
                    _array[i] = values[i];
                }
            }
            else
            {
                throw new ArgumentException("Array is null");
            }
        }


        //добавление значения в конец
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                ReSize();
            }
            _array[Length] = value;
            Length++;
        }


        //добавление значения в начало

        public void AddToStart(int value)
        {
            if (Length == _array.Length)
            {
                ReSize();
            }

            for (int i = Length; i >= 0; --i)
            {
                _array[i + 1] = _array[i];

            }
            _array[0] = value;

            Length++;
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
            ReSize();

            Length--;

        }

        //удаление из начала одного элемента
        public void RemoveElementFromStart()
        {

            for (int i = 1; i <= Length; i++)
            {
                _array[i - 1] = _array[i];
            }

            if (!(Length == 0))
            {
                Length--;
            }

            ReSize();
        }

        //удаление по индексу одного элемента

        public void RemoveElementByIndex(int index)
        {
            if (index >= 0 && index <= Length)
            {

                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }

                --Length;
                ReSize();
            }

        }


        //удаление из конца N элементов
        public void RemoveNElementsFromEnd(int Nvalue)
        {
            Length -= Nvalue;
            ReSize();
        }


        //удаление из начала N элементов
        public void RemoveNElementsFromStart(int Nvalue)
        {
            if (Nvalue < Length && Nvalue >= 0)
            {

                for (int i = Nvalue; i <= Length; i++)
                {
                    _array[i - Nvalue] = _array[i];
                }

                Length -= Nvalue;
                ReSize();
            }
        }

        //удаление по индексу N элементов
        public void RemoveNElementByIndex(int index, int Nvalue)
        {
            if (index < Length && index >= 0 && Length - Nvalue > 0)
            {

                for (int i = index + Nvalue; i <= Length; i++)
                {
                    _array[i - Nvalue] = _array[i];
                }

                Length -= Nvalue;
                ReSize();

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


        //поиск значения максимального элемента
        public int SearchValueMaxElement()
        {
          
            return SearchIndexMaxElement();
        }

        //поиск значения минимального элемента
        public int SearchValueMinElement()
        {
            return SearchIndexMinElement();

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

        //сортировка по возрастанию
        public void SortAscending()
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

        public int RemoveElementByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    RemoveElementByIndex(i);
                    return i;
                }
            }

            return -1;
        }

    

        //удаление по значению всех(?вернуть кол-во)

        public int RemoveAllElementsByValue(int value)
        {
            int countRemoveElements = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    RemoveElementByIndex(i);
                    --i;
                    ++countRemoveElements;
                }
            }

            return countRemoveElements;
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


        public void DescendingSort(bool v)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < Length; i++)
            {
                result += _array[i] + " ";
            }

            return result;
        }


        public override bool Equals(object obj)
        {
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


        private void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }
       

        private void ReSize()
        {
            if ((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLenght = (int)(_array.Length * 1.33 + 1);
                int[] tmpArray = new int[newLenght];

                for (int i = 0; i < Length; i++)
                {
                    tmpArray[i] = _array[i];
                }

                _array = tmpArray;
            }








        }
    }
}
