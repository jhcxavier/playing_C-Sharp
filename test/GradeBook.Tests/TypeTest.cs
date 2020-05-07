using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTest
    {
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
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
            
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
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

        private void SetName(Book book, string name)
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

        Book GetBook(string name)
        {
            return new Book(name);
        }
        // Book GetBook(string name)
        // {
        //     return new Book(name);
        // }

    }
}
