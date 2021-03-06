using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessages);

    public class TypeTest
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementeCount;

            var result = log("Hello!");

            // Assert.Equal("Hello!", result);
            Assert.Equal(3, count);
        }
        string IncrementeCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void BookGreaterThan105()
        {
            InMemoryBook test = new InMemoryBook("Joao's Book");
            var num = 100.0;
            test.AddGrade(num);
            // var test = GetBook("Joao's Book");
            

            Assert.Equal(num, test.grades[0]);
        }

     

        [Fact]
        public void StringBehaveLikeValueType()
        {
            string name = "Joao";
            var upper = MakeUpperCase(name);

            Assert.Equal("Joao", name);
            Assert.Equal("JOAO", upper);
        }

        private string MakeUpperCase(string parameter)
        {
             return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassedByValue()
        {
            var x = GetInt();
            var y = SetInt(x);
            
            Assert.Equal(42, y);
        }

        private int SetInt(int y)
        {
            y = 42;
            return y;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
            
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanChangeName()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // if(book1.Name == "Book 1"){
            //     Assert.Equal("Book 1", book1.Name);
            // }else{
            Assert.Equal("New Name", book1.Name);
            // }
            
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);   
            Assert.True(Object.ReferenceEquals(book1, book2));  
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
        // Book GetBook(string name)
        // {
        //     return new Book(name);
        // }

    }
}
