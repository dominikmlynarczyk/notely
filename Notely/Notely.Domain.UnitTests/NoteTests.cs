using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notely.Domain.Notes;
using Notely.SharedKernel;

namespace Notely.Domain.UnitTests
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void Should_Not_Save_With_Empty_FileName()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Note(new AggregateId(Guid.NewGuid()), String.Empty, "C:/", new AggregateId(Guid.NewGuid())));
        }

        [TestMethod]
        public void Should_Not_Update_Note_After_Empty_Name_Change()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            Assert.ThrowsException<ArgumentNullException>(() => note.Update(String.Empty, "D:/"));
        }

        [TestMethod]
        public void Should_Update_Note_Name()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            note.Update("newTest", "C:/");
            Assert.AreEqual("newTest", note.Name);
        }

        [TestMethod]
        public void Should_Update_Note_Path()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            note.Update("test", "D:/");
            Assert.AreEqual("D:/", note.ContentPath);
        }

        [TestMethod]
        public void Is_Date_Valid_After_Update()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            note.Update("newTest", "D:/");
            Assert.IsInstanceOfType(note.ModifiedDate, typeof(DateTime));
        }

        [TestMethod]
        public void Should_Set_Status_Archived()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            note.Archive();
            Assert.IsTrue(note.IsArchived);
        }

        [TestMethod]
        public void Should_Not_Modified_Date_Equal_Create_Date()
        {
            var note = new Note(new AggregateId(Guid.NewGuid()), "test", "C:/", new AggregateId(Guid.NewGuid()));
            Thread.Sleep(100);
            note.Update("newTest", "D:/");
            Assert.AreNotEqual(note.CreatedDate, note.ModifiedDate);
        }
    }
}
