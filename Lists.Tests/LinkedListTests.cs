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


        [TestCase(3, new int[] { 1, 2 }, new int[] { 3, 1, 2})]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 1, 2, 35,  })]
        public void Add_ValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddToStart(value);

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
        public void Remove_ElementFromEnd(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveElementFromEnd();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 8, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 7, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 6, 1, 2 }, new int[] { 1, 2 })]
        public void Remove_ElementFromStart(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveElementFromStart();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 6, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 5, 3, }, new int[] { 1, 2, 3 })]
        public void Remove_ElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveElementByIndex(index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]

        public void Remove_NElementsFromEnd(int Nvalue, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveNElementsFromEnd(Nvalue);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]

        public void RemoveNElementsFromStart(int Nvalue, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveNElementsFromStart(Nvalue);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, 1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]

        public void RemoveNElementByIndex(int Nvalue, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveNElementByIndex(Nvalue, index);

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

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, }, new int[] { 0, 0, })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        public void Reverse_Array(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            //actual.ReverseArray();

            Assert.AreEqual(expected, actual);
        }



        //[TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        //[TestCase(new int[] { 3, 4, 5 }, 5)]
        //[TestCase(new int[] { 0 }, 0)]
        //[TestCase(new int[] { 8, 7, 5 }, 8)]
        //public void Search_ValueMaxElement(int[] actualArray, int expected)
        //{
        //    ArrayList list = new ArrayList(actualArray);
        //    int actual = list.SearchValueMaxElement();

        //    Assert.AreEqual(expected, actual);
        //}


        //[TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        //[TestCase(new int[] { 8, 7, 6 }, 6)]
        //[TestCase(new int[] { 0 }, 0)]
        //[TestCase(new int[] { 3, 5, 7, 6 }, 3)]
        //public void Search_ValueMinElement(int[] actualArray, int expected)
        //{
        //    ArrayList list = new ArrayList(actualArray);
        //    int actual = list.SearchValueMinElement();

        //    Assert.AreEqual(expected, actual);
        //}


        [TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 9, 8, 7 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 5, 8, 6 }, 1)]
        public void Search_IndexMaxElement(int[] actualArray, int expected)
        {
            LinkedList array = new LinkedList(actualArray);

            int actual = array.SearchIndexMaxElement();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        [TestCase(new int[] { 9, 8, 7 }, 2)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 5, 8, 6 }, 0)]
        public void Search_IndexMinElement(int[] actualArray, int expected)
        {
            LinkedList array = new LinkedList(actualArray);

            int actual = array.SearchIndexMinElement();

            Assert.AreEqual(expected, actual);
        }






        [TestCase(new int[] { 3, 1, 8, 4, 6, }, new int[] { 1, 3, 4, 6, 8 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 7 }, new int[] { 7 })]
        public void Sort_Ascending(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }


        //[TestCase(new int[] { 2, 5, 8, 4, 6 }, new int[] { 8, 6, 5, 4, 2 })]
        //[TestCase(new int[] { 2, 6, 5 }, new int[] { 6, 5, 2 })]
        //[TestCase(new int[] { }, new int[] { })]

        //public void Descending_Sort(int[] actualArray, int[] expectedArray)
        //{
        //    LinkedList actual = new LinkedList(actualArray);
        //    LinkedList expected = new LinkedList(expectedArray);

        //    actual.DescendingSort();

        //    Assert.AreEqual(expected, actual);
        //}




        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5, 1 })]
        public void Add_ArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList addList = new LinkedList(new int[] { 1, 2, 3, 4, 5 });

            actual.AddLinkedList(addList);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 77, 77, 77, 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 77, 77, 77, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 77, 77, 77, 3 })]

        public void Add_LinkedListByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList addList = new LinkedList(new int[] { 77, 77, 77 });

            actual.AddLinkedListByIndex(addList, index);

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

            actual.AddLinkedListByIndex(list, index);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        public void AddLinkedList_ThenAddListInLast(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList list = new LinkedList(arrayForList);
            LinkedList expectedArrayList = new LinkedList(expectedArray);

            actual.AddLinkedList(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddFirst_WhenListPassed_ThenAddListInFirst(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList list = new LinkedList(arrayForList);
            LinkedList expectedArrayList = new LinkedList(expectedArray);

            actual.AddLinkedListToStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }






    }
}