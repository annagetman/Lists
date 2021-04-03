using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    class DoubleLinkedListTests
    {
        [TestCase(1, new int[] { 5, 10, 15 }, 10)]
        public void GetIndex_WhenIndex_ShouldValueByIndex(int index, int[] actualArray, int expected)
        {
            DoubleLinkedList expectedArray = DoubleLinkedList.Create(actualArray);

            int actual = expectedArray[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void LinkedListConstructor_WhenListPassed_ShouldArgumentNullException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList.Create(null);
            });
        }

        [TestCase(2, 1)]
        public void LinkedListConstructor_WhenObjectOfAClassIsCreated_Length1(int value, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(value);
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        public void LinkedListConstructor_WhenObjectOfAClassIsCreated_LengthEqualsZero(int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList();
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }



        [TestCase(3, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddValue_WhenValuePassed_AddValueToLast(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddValueToStart__WhenValuePassed_AddValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.AddValueToStart(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, 0, new int[] { 1, 2, 3 }, new int[] { 7, 1, 2, 3 })]
        [TestCase(5, 1, new int[] { 1, 2, 3 }, new int[] { 1, 5, 2, 3 })]
        [TestCase(4, 3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4 })]
        [TestCase(3, 0, new int[] { }, new int[] { 3 })]
        public void AddValueByIndex_WhenValueAndIndex_AddValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -2, 7, new int[] { 7, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 7, 10, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        public void AddByIndex_WhenValueAndIndexPassed_ReturnIndexOutOfRangeException(int[] actualArray, int index, int value, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

                actual.AddValueByIndex(index, value);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 2 }, new int[] { 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLastElem_WhenElemem_RemoveLastElem(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveLastElement_WhenIndexPassed_ReturnNullReferenceException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveLastElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirst_WhenElemem_RemoveFirst(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveFirst_WhenIndexPassed_ReturnNullReferenceException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveFirst();
            });
        }

        [TestCase(0, new int[] { 1 }, new int[] { })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2 })]
        public void RemoveByIndex_WhenIndex_RemoveElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 6)]
        public void RemoveByIndex_WhenIndexPassed_ReturnIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveByIndex(index);
            });
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1 })]
        public void Remove_NElementsFromLast_WhenNElements_RemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemovNElementsFromLast(nvalue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -2)]
        public void RemovNElementsFromLast_WhenNElements_ReturnArgumentException(int[] actualArray, int nElements)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(new int[] { 3, 2, 1 }, 5)]
        public void RemovNElementsFromLast_WhenNElements_ReturnIndexOutOfRangeException(int[] actualArray, int nElements)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5 })]
        public void RemoveNElementsFromStart_WhenNElements_RemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemovNElementsFromStart(nvalue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 5 }, -1)]
        public void RemovNElementsFromStart_WhenNElements_ReturnArgumentException(int[] actualArray, int nElements)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromStart(nElements);
            });
        }

        [TestCase(new int[] { 11, 12, 13 }, 10)]
        public void RemovNElementsFromStart_WhenNElements_ReturnIndexOutOfRangeException(int[] actualArray, int nElements)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(1, 0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(3, 0, new int[] { 1, 2, 3 }, new int[] { })]
        [TestCase(4, 1, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]
        public void RemoveByIndexNElements_WhenIndexAndNElements_RemoveByIndexNElements(int nvalue, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByIndexNElements(nvalue, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 9 }, -1, 1)]
        public void RemoveByIndexNElements_WhenNElements_ReturnArgumentException(int[] actualArray, int nElements, int index)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveByIndexNElements(nElements, index);
            });
        }

        [TestCase(new int[] { 1, 5, 3 }, 2, 4)]
        public void RemoveByIndexNElements_WhenNElements_ReturnIndexOutOfRangeException(int[] actualArray, int nElements, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveByIndexNElements(nElements, index);
            });
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, -1)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(8, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        public void GetIndexByValue_WhenValue_ReturnIndex(int value, int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 2, 4, 5, 6, 7, 8 })]
        [TestCase(10, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 10, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(1, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 1 })]

        public void GetChangeByIndex_WhenValue_ReturnIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, 7 }, 5, 13)]
        public void GetChangeByIndex_WhenIndexAndNElements_ReturnIndexOutOfRangeException(int[] actualArray, int index, int value)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.GetChangeByIndex(index, value);
            });
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 7, 8 }, new int[] { 8, 7 })]

        public void Revers(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.Revers();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3, 6, 5 }, 2)]
        [TestCase(new int[] { 8, 2, 5, 5, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 1, 5, 6, 7, 9 }, 7)]
        public void FindMaxIndex_WhenMethodCalled_ReturnMaxIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.FindIndexOfMaxElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 3)]
        public void FindIndexOfMaxElem_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList list = DoubleLinkedList.Create(actualArray);
                int actual = list.FindIndexOfMaxElem();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 6)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 2)]
        public void FindMinIndex_WhenMethodCalled_ReturnMinIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.FindIndexOfMinElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 5)]
        public void FindIndexOfMinElem_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList list = DoubleLinkedList.Create(actualArray);
                int actual = list.FindIndexOfMinElem();
            });
        }

        [TestCase(new int[] { 7, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 0, 3, 4, 5, 6, 7, 9 }, 6)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 1)]
        public void FindValueOfMaxElem_WhenMethodCalled_ReturnMaxIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.FindValueOfMaxElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 6)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 2)]
        public void FindValueOfMinElem_WhenMethodCalled_ReturnValueOfMinElem(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.FindValueOfMinElem();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { -1, 1, 1, 3, 4, 6, 8, 12 })]
        public void GetAscendingSort_WhenMethodCalled_SortbyAscending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetSortByAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { 12, 8, 6, 4, 3, 1, 1, -1 })]
        public void GetDescendingSort_WhenMethodCalled_SortbyAscending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetDescendingSort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 5, 2, 3 }, new int[] { 1, 5, 3 })]
        [TestCase(7, new int[] { 1, 2, 3, 7 }, new int[] { 1, 2, 3 })]

        public void Remove_ElementByValue_WhenValue_RemoveValue(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByValueFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 2, 4, 2, 6, 7, 8 }, 2, new int[] { 1, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 3, 3, 3 }, 3, new int[] { })]
        public void RemoveAllByValue_WhenValue_RemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddListToTheEnd_WhenListPassed_AddListToTheEnd(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListToTheEnd(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        public void AddListToTheEnd_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListToTheEnd(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 10 }, new int[] { 10, 1, 2, 3 })]
        public void AddListToStart_WhenListPassed_ThenAddLisToStart(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListToStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        public void AddListToStart_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListToStart(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 5, 6, 7 }, new int[] { 1, 5, 6, 7, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        public void AddByIndex_WhenListAndIndexPassed_ThenAddListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListByIndex(list, index);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { })]
        public void AddListByIndex_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListByIndex(list, index);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 5, new int[] { 5, 7, 9 })]
        public void AddListByIndex_WhenMethodCalled_ReturnIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListByIndex(list, index);
            });
        }

        [TestCase(new int[] { 2, 4, 6 }, "2 4 6 ")]
        [TestCase(new int[] { 5 }, "5 ")]
        [TestCase(new int[] { }, "")]
        public void ToString_WhenArrayListPassed_ShouldString(int[] array, string expected)
        {
            DoubleLinkedList arrayList = DoubleLinkedList.Create(array);

            string actual = arrayList.ToString();

            Assert.AreEqual(expected, actual);
        }


    }
}
