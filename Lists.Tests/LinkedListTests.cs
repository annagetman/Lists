using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    class LinkedListTests
    {

        [TestCase(3, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 2, 35, 1 })]
        public void Add_ValueToEnd(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(3, new int[] { }, new int[] { 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 1, 2, 35, })]
        public void Add_ValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddValueToStart(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(7, 0, new int[] { 1, 2, 3 }, new int[] { 7, 1, 2, 3 })]
        [TestCase(5, 1, new int[] { 1, 2, 3 }, new int[] { 1, 5, 2, 3 })]
        [TestCase(3, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        public void Add_ValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void Remove_LastElement(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 8, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 7, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 6, 1, 2 }, new int[] { 1, 2 })]
        public void Remove_ElementFromStart(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 6, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 5, 3, }, new int[] { 1, 2, 3 })]
        public void Remove_ElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]

        public void Remove_NElementsFromEnd(int Nvalue, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemovNElementsFromLast(Nvalue);

            Assert.AreEqual(expected, actual);
        }




        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5 })]
        public void RemoveNElementsFromStart_WhenNElements_RemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemovNElementsFromStart(nvalue);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(1, 3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(3, 0, new int[] { 1, 2, 3 }, new int[] { })]

        public void RemoveByIndexNElements_WhenIndexAndNElements_RemoveByIndexNElements(int nvalue, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndexNElements(nvalue, index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, new int[] { 0, 1, 2, 3 }, 2)]
        [TestCase(1, new int[] { 0, 1, 2, 3 }, 1)]
        [TestCase(3, new int[] { 0, 1, 2, 3 }, 3)]

        public void SearchFirstIndexByValue(int value, int[] actualArray, int expected)
        {
            LinkedList array = new LinkedList(actualArray);

            int actual = array.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 7, 8 }, new int[] { 8, 7 })]

        public void Revers(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Revers();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3, 6, 5 }, 2)]
        [TestCase(new int[] { 8, 2, 5, 5, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 1, 5, 6, 7, 9 }, 7)]
        public void FindMaxIndex_WhenMethodCalled_ReturnMaxIndex(int[] actualArray, int expected)
        {
            LinkedList index = new LinkedList(actualArray);
            int actual = index.FindIndexOfMaxElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 3)]
        public void FindIndexOfMaxElem_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList list = new LinkedList(actualArray);
                int actual = list.FindIndexOfMaxElem();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 6)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 2)]
        public void FindMinIndex_WhenMethodCalled_ReturnMinIndex(int[] actualArray, int expected)
        {
            LinkedList index = new LinkedList(actualArray);
            int actual = index.FindIndexOfMinElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 5)]
        public void FindIndexOfMinElem_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList list = new LinkedList(actualArray);
                int actual = list.FindIndexOfMinElem();
            });
        }

        [TestCase(new int[] { 7, 2, 3, 4, 5 }, 7)]
        [TestCase(new int[] { 0, 3, 4, 5, 6, 7, 9 }, 9)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 6)]
        public void FindValueOfMaxElem_WhenMethodCalled_ReturnMaxIndex(int[] actualArray, int expected)
        {
            LinkedList index = new LinkedList(actualArray);
            int actual = index.FindValueOfMaxElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 1)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 1)]
        public void FindValueOfMinElem_WhenMethodCalled_ReturnValueOfMinElem(int[] actualArray, int expected)
        {
            LinkedList index = new LinkedList(actualArray);
            int actual = index.FindValueOfMinElem();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 3, 1, 8, 4, 6, }, new int[] { 1, 3, 4, 6, 8 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 7 }, new int[] { 7 })]
        public void Sort_Ascending(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.GetSortByAscending();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 5, 8, 4, 6 }, new int[] { 8, 6, 5, 4, 2 })]
        [TestCase(new int[] { 2, 6, 5 }, new int[] { 6, 5, 2 })]
        [TestCase(new int[] { }, new int[] { })]

        public void Descending_Sort(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.GetDescendingSort();

            Assert.AreEqual(expected, actual);
        }




        [TestCase(7, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(7, new int[] { 1, 2, 7, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(7, new int[] { 1, 2, 3, 7 }, new int[] { 1, 2, 3 })]

        public void Remove_ElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByValueFirst(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(7, new int[] { 7, 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(7, new int[] { 7, 7, 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(7, new int[] { 7, 7, 7, 7, 1, 2, 3, }, new int[] { 1, 2, 3 })]

        public void Remove_AllElementsByValue(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddLinkedListByIndex_WhenListAndIndexPassed_ThenAddLinkedListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList list = new LinkedList(arrayForList);
            LinkedList expectedArrayList = new LinkedList(expectedArray);

            actual.AddListByIndex(list, index);

            Assert.AreEqual(expectedArrayList, actual);
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        public void AddListToTheEnd_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                LinkedList actual = new LinkedList(actualArray);
                LinkedList list = new LinkedList(arrayForList);
                actual.AddListToTheEnd(list);
            });
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 10 }, new int[] { 10, 1, 2, 3 })]
        public void AddListToStart_WhenListPassed_ThenAddLisToStart(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList list = new LinkedList(arrayForList);
            LinkedList expectedArrayList = new LinkedList(expectedArray);

            actual.AddListToStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }







    }
}