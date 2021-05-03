using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
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

        private DNode _root;

        private DNode _tail;

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        private DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        private DNode GetNodeByIndex(int index)
        {
            DNode current;
            if (index > Length / 2 + 1)
            {
                current = _tail;
                for (int i = Length - 1; i > index; i--)
                {
                    current = current.Previous;
                }
                return current;
            }
            else
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DNode(value);
            _tail = _root;
        }

        public static DoubleLinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new DoubleLinkedList(values);
            }
            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new DNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }
            else
            {
                _root = new DNode(value);
                _tail = _root;
            }
            Length++;
        }

        public void AddValueToStart(int value)
        {
            if (Length != 0)
            {
                DNode first = new DNode(value);
                _root.Previous = first;
                first.Next = _root;
                _root = first;
            }
            else
            {
                _root = new DNode(value);
                _tail = _root;
            }
            Length++;
        }

        public void AddValueByIndex(int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length != 0)
                {
                    if (index == 0)
                    {
                        AddValueToStart(value);
                        Length--;
                    }
                    else
                    {
                        DNode nodeByIndex = new DNode(value);
                        DNode current = GetNodeByIndex(index - 1);
                        nodeByIndex.Next = current.Next;
                        current.Next.Previous = nodeByIndex;
                        current.Next = nodeByIndex;
                        nodeByIndex.Previous = current;
                    }
                }
                else
                {
                    _root = new DNode(value);
                    _tail = _root;
                }
                Length++;
            }
            else
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }

        public void RemoveElementFromEnd()
        {
            if (Length > 1)
            {
                DNode current = GetNodeByIndex(Length - 2);
                current.Next = null;
                Length--;
            }
            else if (Length == 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveElementFromStart()
        {
            if (Length > 1)
            {
                _root = _root.Next;

                Length--;
            }
            else if (Length == 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveElementByIndex(int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length != 0)
                {
                    if (index != 0 && index < Length - 1)
                    {
                        DNode current = GetNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        current.Next.Previous = current;
                        Length--;
                    }
                    else if (index == 0)
                    {
                        RemoveElementFromStart();
                    }
                    else
                    {
                        RemoveElementFromEnd();
                    }
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
                throw new IndexOutOfRangeException("Error");
            }
        }

        public void RemoveNElementsFromEnd(int nvalue)
        {
            if (nvalue < Length)
            {
                if (!(nvalue < 0))
                {
                    DNode current = GetNodeByIndex(Length - nvalue);
                    current.Next = _tail;
                    _tail.Next = null;

                    Length -= nvalue;
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else if (nvalue == Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }

        public void RemovNElementsFromStart(int nvalue)
        {
            if (nvalue < Length)
            {
                if (!(nvalue < 0))
                {
                    DNode current = GetNodeByIndex(nvalue - 1);
                    _root = current.Next;

                    Length -= nvalue;
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else if (nvalue == Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }

        public void RemoveNElementsByIndex(int nvalue, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemovNElementsFromStart(nvalue);
                }
                else if (nvalue == Length - 1)
                {
                    RemoveNElementsFromEnd(nvalue);
                }
                else if (nvalue > 0)
                {
                    if (!(nvalue + index >= Length))
                    {
                        DNode startNode = GetNodeByIndex(index - 1);
                        DNode finishNode = GetNodeByIndex(index + nvalue);

                        startNode.Next = finishNode;
                        finishNode.Previous = startNode;

                        Length -= nvalue;
                    }
                    else
                    {
                        DNode current = GetNodeByIndex(index);

                        current.Next = null;
                        _tail = current;
                        Length = index + 1;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }

        public int SearchFirstIndexByValue(int value)
        {
            DNode current = _root;

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

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    DNode current = _root;
                    DNode tmp = _tail;
                    int value;
                    int count = 0;

                    while (count != Length / 2)
                    {
                        value = current.Value;
                        current.Value = tmp.Value;
                        tmp.Value = value;
                        current = current.Next;
                        tmp = tmp.Previous;

                        ++count;
                    }
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
        public int SearchIndexMaxElement()
        {
            if (Length != 0 || this is null)
            {
                DNode current = _root;
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
            else
            {
                throw new ArgumentException("List is null");
            }
        }

        public int FindIndexOfMinElem()
        {
            if (Length != 0 || this is null)
            {
                DNode current = _root;
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
            else
            {
                throw new ArgumentException("List is null");
            }
        }

        public int SearchValueMaxElement()
        {
            if (Length != 0)
            {
                int max = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (max < GetNodeByIndex(i).Value)
                    {
                        max = GetNodeByIndex(i).Value;
                    }
                }
                return max;
            }
            throw new ArgumentException("Length list is  zero");
        }

        public int SearchValueMinElement()
        {
            if (Length != 0)
            {
                int min = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (min > GetNodeByIndex(i).Value)
                    {
                        min = GetNodeByIndex(i).Value;
                    }
                }
                return min;
            }
            throw new ArgumentException("Length list is  zero");
        }

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

        public void DescendingSort()
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(max).Value < GetNodeByIndex(j).Value)
                    {
                        max = j;
                    }
                }
                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(max).Value;
                GetNodeByIndex(max).Value = temp;
            }
        }

        public void RemoveElementByValue(int value)
        {
            int index = SearchFirstIndexByValue(value);

            if (!(value == -1))
            {
                RemoveElementByIndex(index);
            }
        }

        public void RemoveAllElementsByValue(int value)
        {
            int indexOfElements = SearchFirstIndexByValue(value);

            while (indexOfElements != -1)
            {
                RemoveElementByIndex(indexOfElements);
                indexOfElements = SearchFirstIndexByValue(value);
            }
        }

        public void AddArrayList(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    _tail.Next = secondList._root;
                    secondList._root.Previous = _tail;
                    _tail = secondList._tail;

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

        public void AddDoubleLinkedListToStart(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    secondList._tail.Next = _root;
                    _root.Previous = secondList._tail;
                    _root = secondList._root;

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

        public void AddDoubleLinkedListByIndex(DoubleLinkedList secondList, int index)
        {
            if (secondList.Length != 0)
            {
                if (index >= 0 && index <= Length)
                {
                    if (Length != 0)
                    {
                        if (index == 0)
                        {
                            AddDoubleLinkedListToStart(secondList);
                        }
                        else
                        {
                            DNode current = GetNodeByIndex(index - 1);
                            secondList._tail.Next = current.Next;
                            current.Next.Previous = secondList._tail;
                            current.Next = secondList._root;
                            secondList._root.Previous = current;
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
                DNode current = _root;
                string str = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    str += current.Value + " ";
                }
                return str.Trim();
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
                    DNode currentThis = this._root;
                    DNode currentList = list._root;
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
    }
}
