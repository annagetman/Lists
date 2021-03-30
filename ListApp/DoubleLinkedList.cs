using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class DoubleLinkedList
    {

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }
            set
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;

        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }



        //добавление значения в конец
        public void Add(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        //добавление значения в начало

        public void AddToStart(int value)
        {
            Length++;

            Node first = new Node(value);

            first.Next = _root;
            _root = first;
        }


        //добавление значения по индексу

        public void AddValueByIndex(int value, int index)
        {
            if (Length != 0)
            {
                Node ByIndex = new Node(value);

                Node current = GetNodeByIndex(index - 1);

                ByIndex.Next = current.Next;
                current.Next = ByIndex;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }

            Length++;
        }

        //удаление из конца одного элемента

        public void RemoveElementFromEnd()
        {
            RemoveElementByIndex(Length - 1);

        }

        //удаление из начала одного элемента
        public void RemoveElementFromStart()
        {
            _root = _root.Next;
            Length--;
        }

        //удаление по индексу одного элемента

        public void RemoveElementByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;

            Length--;
        }


        //удаление из конца N элементов
        public void RemoveNElementsFromEnd(int Nvalue)
        {
            if (Nvalue != Length)
            {
                Node current = GetNodeByIndex(Length - Nvalue);
                current.Next = _tail;

                Length -= Nvalue;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }


        //удаление из начала N элементов
        public void RemoveNElementsFromStart(int Nvalue)
        {
            if (Nvalue != Length)
            {
                Node current = GetNodeByIndex(Nvalue - 1);
                _root = current.Next;

                Length -= Nvalue;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        //удаление по индексу N элементов
        public void RemoveNElementByIndex(int index, int Nvalue)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveNElementsFromStart(Nvalue);
                }

                else if (Nvalue == Length - 1)
                {
                    RemoveNElementsFromEnd(Nvalue);
                }

                else if (Nvalue > 0)
                {
                    if (!(Nvalue + index >= Length))
                    {
                        Node startNode = GetNodeByIndex(index - 1);
                        Node finishNode = GetNodeByIndex(index + Nvalue);

                        startNode.Next = finishNode;

                        Length -= Nvalue;
                    }
                    else
                    {
                        Node current = GetNodeByIndex(index);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Error!");
            }
        }



        //первый индекс по значению
        public int SearchFirstIndexByValue(int value)
        {
            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }

                current = current.Next;
            }

            return -1;
        }


        public void GetChangeByIndex(int index, int value)
        {
            if (index >= 0 && index <= Length)
            {
                Node current = GetNodeByIndex(index);

                current.Value = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Error");
            }

        }

        //реверс(123 -> 321)

        //public void ReverseLinkedList()
        //{

        //}

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
            Node current = _root;
            int maxIndex = 0;
            int temp = 0;

            for (int i = 0; i < Length; i++)
            {
                if (temp < current.Value)
                {
                    maxIndex = i;
                    temp = current.Value;
                }

                current = current.Next;
            }

            return maxIndex;
        }
        //поиск индекс минимального элемента

        public int SearchIndexMinElement()
        {
            {

                Node current = _root;
                int minIndex = 0;
                int temp = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (temp > current.Value)
                    {
                        minIndex = i;
                        temp = current.Value;
                    }

                    current = current.Next;
                }

                return minIndex;
            }
        }

        //сортировка по возрастанию
        //public void SortAscending(int value)
        //{

        //}

        ////сортировка по убыванию
        //public void DescendingSort(int value)
        //{

        //}

        ////удаление по значению первого(?вернуть индекс)

        //public void RemoveElementByValue(int value)
        //{

        //}


        ////удаление по значению всех(?вернуть кол-во)

        //public void RemoveAllElementsByValue(int value)
        //{

        //}


        ////добавление списка(вашего самодельного) в конец
        //public void AddArrayList(ArrayList list)
        //{

        //}

        ////добавление списка в начало

        //public void AddArrayListToStart(ArrayList list)
        //{

        //}

        ////добавление списка по индексу
        //public void AddArrayListByIndex(ArrayList list, int index)
        //{ }







        private Node GetNodeByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (current.Next! is null)
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                return s;
            }
            else
            {
                return String.Empty;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is DoubleLinkedList || obj is null)
            {
                DoubleLinkedList list = (DoubleLinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    Node currentThis = this._root;
                    Node currentList = list._root;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isEqual = false;
                            break;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not DoubleLinkedList");
        }
    }
}
