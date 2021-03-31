using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }

            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;

        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
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
        public int GetIndexByValue(int value)
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

        public void ReverseLinkedList()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    Node prev = null;
                    Node next = null;
                    Node current = _root;
                    while (current != null)
                    {
                        next = current.Next;
                        current.Next = prev;
                        prev = current;
                        current = next;
                    }
                    _root = prev;
                }

                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new NullReferenceException("Error, null");
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
        public void SortAscending()
        {
            for (int i = 0; i < Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(min).Value > GetNodeByIndex(j).Value)
                    {
                        min = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(min).Value;
                GetNodeByIndex(min).Value = temp;
            }

        }


        //удаление по значению первого(?вернуть индекс)

        public void RemoveByValueFirst(int value)
        {
            int index = GetIndexByValue(value);

            if (!(value == -1))
            {
                RemoveElementByIndex(index);
            }
        }


        ////удаление по значению всех(?вернуть кол-во)

        public void RemoveByValueAll(int value)
        {
            int indexOfElements = GetIndexByValue(value);

            while (indexOfElements != -1)
            {
                RemoveElementByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }

        }

        ////добавление списка(вашего самодельного) в конец
        public void AddLinkedList(LinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList != null)
                {
                    _tail.Next = secondList._root;
                    Length += secondList.Length;

                }
                else
                {
                    throw new ArgumentException("No elements in list!");
                }
            }
            else
            {
                _root = secondList._root;
                _tail = secondList._tail;

                Length = secondList.Length;
            }

        }

        ////добавление списка в начало

        public void AddLinkedListToStart(LinkedList secondList)
        {
            if (secondList != null)
            {
                if (Length != 0)
                {
                    secondList._tail.Next = _root;
                    _root = secondList._root;

                    Length += secondList.Length;
                }
                else
                {
                    _root = secondList._root;
                    _tail = secondList._tail;

                    Length = secondList.Length;
                }
            }
            else
            {
                throw new ArgumentException("No elements in list!");
            }
        }

        ////добавление списка по индексу
        public void AddLinkedListByIndex(LinkedList secondList, int index)
        {
            if (secondList != null)
            {
                if (index >= 0 && index <= Length)
                {
                    if (Length != 0)
                    {
                        if (index == 0)
                        {
                            AddLinkedListToStart(secondList);
                        }
                        else
                        {
                            Node current = GetNodeByIndex(index - 1);

                            secondList._tail.Next = current.Next;
                            current.Next = secondList._root;

                            Length += secondList.Length;
                        }
                    }
                    else
                    {
                        _root = secondList._root;
                        _tail = secondList._tail;

                        Length = secondList.Length;
                    }
                }

                else
                {
                    throw new IndexOutOfRangeException("Out of range!");
                }
            }

            else
            {
                throw new ArgumentException("No elements in list!");
            }
        }









        





        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
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
            if (obj is LinkedList || obj is null)
            {
                LinkedList list = (LinkedList)obj;
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

            throw new ArgumentException("obj is not List");
        }

        private Node GetNodeByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }








    }
}

