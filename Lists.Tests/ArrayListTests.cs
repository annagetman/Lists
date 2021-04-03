using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    public class ArrayListTests
    {
        [TestCase(1, new int[] { 5, 10, 15 }, 10)]
        public void GetIndex_WhenIndex_ShouldValueByIndex(int index, int[] actualArray, int expected)
        {
            ArrayList expectedArray = ArrayList.Create(actualArray);

            int actual = expectedArray[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        public void ArrayListConstructor_WhenObjectOfAClassIsCreated_LengthEqualsZero(int expected)
        {
            ArrayList actualList = new ArrayList();
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1)]
        public void ArrayListConstructor_WhenObjectOfAClassIsCreated_Length1(int value, int expected)
        {
            ArrayList actualList = new ArrayList(value);
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void ArrayList_WhenListPassed_ShouldArgumentNullException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                ArrayList.Create(null);
            });
        }

        [TestCase(7, new int[] { }, new int[] { 7 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(3, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 2, 35, 1 })]
        public void Add_ValueToEnd_WhenValuePassed_AddValueToEnd(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(3, new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(25, new int[] { 1, 2 }, new int[] { 25, 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        public void AddValueToStart__WhenValuePassed_AddValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddToStart(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(7, 0, new int[] { 1, 2, 3 }, new int[] { 7, 1, 2, 3 })]
        [TestCase(5, 1, new int[] { 1, 2, 3 }, new int[] { 1, 5, 2, 3 })]
        [TestCase(3, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        [TestCase(1, 3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 1, 4 })]
        [TestCase(1, 0, new int[] { }, new int[] { 1 })]
        public void Add_ValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 7, new int[] { 1, 2, 3, 4 })]
        public void Add_ValueByIndex_WhenValueAndNotCorrectIndexPassed_ReturnIndexOutOfRangeException(int value, int index, int[] actualArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.AddValueByIndex(value, index);
            });
        }


        [TestCase(new int[] { 1, 2, 25 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 444 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 77 }, new int[] { })]
        public void RemoveElementFromEnd_WhenValuePassed_RemoveElementFromEnd(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveElementFromEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        public void RemoveElementFromEnd_WhenMethodCalledPassed_ReturnIndexOutOfRangeException(int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveElementFromEnd();
            });
        }


        [TestCase(new int[] { 8, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 7, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 6, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 88, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 1, 2 }, new int[] { 1, 2 })]
        public void RemoveElementFromStart_WhenValuePassed_RemoveElementFromStart(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveElementFromStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        public void RemoveElementFromStart_WhenMethodCalledPassed_ReturnIndexOutOfRangeException(int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveElementFromStart();
            });
        }


        [TestCase(0, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 6, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 5, 3, }, new int[] { 1, 2, 3 })]
        //[TestCase(3, new int[] { 1, 2, 3, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 55, 3, }, new int[] { 1, 2, 3 })]
        public void Remove_ElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveElementByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { }, new int[] { })]
        public void RemoveElementByIndex_WhenMethodCalledPassed_ReturnIndexOutOfRangeException(int index, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveElementByIndex(index);
            });
        }



        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1 })]
        [TestCase(0, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(2, new int[] { 1, 2 }, new int[] { })]

        public void Remove_NElementsFromEnd(int Nvalue, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsFromEnd(Nvalue);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, new int[] { }, new int[] { })]
        public void RemoveNElementsFromEnd_WhenMethodCalledPassed_ReturnIndexOutOfRangeException(int index, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromEnd(index);
            });
        }


        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]

        public void RemoveNElementsFromStart(int Nvalue, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsFromStart(Nvalue);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, new int[] { }, new int[] { })]
        public void RemoveNElementsFromStart_WhenMethodCalledPassed_ReturnIndexOutOfRangeException(int index, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromStart(index);
            });
        }


        [TestCase(0, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, 1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]
        [TestCase(0, 3, new int[] { 1, 2, 3 }, new int[] { })]

        public void RemoveNElementByIndex_WhenIndexAndNElements_RemoveNElementByIndex(int index, int Nvalue, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementByIndex(index, Nvalue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -5, new int[] { 1, 2, 3 })]
        //[TestCase(0, 7, new int[] { 1, 2, 3 })]
        public void RemoveNElementsByIndex_WhenNElementsPassed_ReturnArgumentException(int index, int Nvalue, int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementByIndex(index, Nvalue);
            });
        }


        [TestCase(2, new int[] { 0, 1, 2, 3 }, 2)]
        [TestCase(1, new int[] { 0, 1, 2, 3 }, 1)]
        [TestCase(3, new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(1, new int[] { 1, 2, 3, 4 }, 0)]
        public void SearchFirstIndexByValue(int value, int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.SearchFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, }, new int[] { 0, 0, })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_Array(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.ReverseArray();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 9, 8, 7 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 5, 8, 6 }, 1)]
        public void Search_IndexMaxElement(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.SearchIndexMaxElement();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 5)]
        public void SearchIndexMaxElement_WhenMethodCalledPassed_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.SearchIndexMaxElement();
            });
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        [TestCase(new int[] { 9, 8, 7 }, 2)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 5, 8, 6 }, 0)]
        public void Search_IndexMinElement(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.SearchIndexMinElement();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 5)]
        public void SearchIndexMinElement_WhenMethodCalledPassed_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.SearchIndexMinElement();
            });
        }


        [TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 3, 4, 5 }, 2)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 8, 7, 5 }, 0)]
        public void Search_ValueMaxElement(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.SearchValueMaxElement();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 5)]
        public void SearchValueMaxElement_WhenMethodCalledPassed_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.SearchValueMaxElement();
            });
        }


        [TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        [TestCase(new int[] { 8, 7, 6 }, 2)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 3, 5, 7, 6 }, 0)]
        public void Search_ValueMinElement(int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.SearchValueMinElement();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 5)]
        public void SearchValueMinElement_WhenMethodCalledPassed_ReturnArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.SearchValueMinElement();
            });
        }




        [TestCase(new int[] { 3, 1, 8, 4, 6, }, new int[] { 1, 3, 4, 6, 8 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 7 }, new int[] { 7 })]
        public void Sort_Ascending(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 5, 8, 4, 6 }, new int[] { 8, 6, 5, 4, 2 })]
        [TestCase(new int[] { 2, 6, 5 }, new int[] { 6, 5, 2 })]
        [TestCase(new int[] { }, new int[] { })]

        public void DescendingSort(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.DescendingSort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 6, 7 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 3, 4, 5, 6, 7 })]
        [TestCase(7, new int[] { 7, 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        public void RemoveElementByValue_WhenValue_RemoveElementByValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveElementByValue(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 1, 2, 3 }, 2, new int[] { 1, 1, 3 })]
        [TestCase(new int[] { 8, 26, 4, 6, 8, 2, 3, 4 }, 8, new int[] { 26, 4, 6, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 7, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 3, 3, 3 }, 3, new int[] { })]
        public void RemoveAllElementsByValue_WhenValue_RemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveAllElementsByValue(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 8, 8 }, new int[] { 1, 2, 3, 8, 8 })]
        public void Add_ArrayList_WhenListPassed_ThenAddList(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList list = ArrayList.Create(arrayForList);
            ArrayList expectedArrayList = ArrayList.Create(expectedArray);

            actual.AddArrayList(list);

            Assert.AreEqual(expectedArrayList, actual);
        }



        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 8 }, new int[] { 8, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 1, 2, 1, 2, 3 })]
        public void AddArrayListToStart_WhenListPassed_AddArrayListToStart(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList list = ArrayList.Create(arrayForList);
            ArrayList expectedArrayList = ArrayList.Create(expectedArray);

            actual.AddArrayListToStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }


        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 77, 77, 77, 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 77, 77, 77, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 77, 77, 77, 3 })]

        public void Add_ArrayListByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);
            ArrayList addList = ArrayList.Create(new int[] { 77, 77, 77 });

            actual.AddArrayListByIndex(addList, index);

            Assert.AreEqual(expected, actual);
        }

    }
}