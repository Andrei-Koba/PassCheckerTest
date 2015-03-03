using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassCheck;
using System.Diagnostics;
using Rhino.Mocks;

namespace PassChecherTest
{
    [TestClass]
    public class VerifyTest
    {
        [TestMethod]
        public void VerifyTest_If_Password_Lenght_Less_than_7_Return_False()
        {
            string pass = "B575";
            Result expected = new Result(false, "Pass should have 7 character lenght");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(0)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Lenght_Less_than_7_Return_True()
        {
            string pass = "B575v34frsadf23";
            Result expected = new Result(true, "OK");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(1)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Contains_At_Least_One_Alphabetical_Character_Return_False()
        {
            string pass = "536365362654";
            Result expected = new Result(false, "Pass should contain at least one alphabetical character");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(0)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Contains_At_Least_One_Alphabetical_Character_Return_True()
        {
            string pass = "53asf4w3rfdsfsa";
            Result expected = new Result(true, "OK");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(1)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Contains_At_Least_One_Digit_Character_Return_False()
        {
            string pass = "fdsgsrahAFRSGTADF";
            Result expected = new Result(false, "Pass should contain at least one digit");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(0)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Contains_At_Least_One_Digit_Character_Return_True()
        {
            string pass = "fd3542srahA65TADF";
            Result expected = new Result(true, "OK");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", false);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", false),
                options => options.Repeat.Times(1)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Length_More_Than_10_Chars_For_Admins_Return_False()
        {
            string pass = "fd3542s";
            Result expected = new Result(false, "Admin pass should have 10 character lenght");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", true);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", true),
                options => options.Repeat.Times(0)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_Length_More_Than_10_Chars_For_Admins_Return_True()
        {
            string pass = "fd3542s1324fsf%#$%";
            Result expected = new Result(true, "OK");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", true);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", true),
                options => options.Repeat.Times(1)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_contains_At_Least_One_Special_Character_For_Admins_Return_False()
        {
            string pass = "fd3542s1324fsf";
            Result expected = new Result(false, "Admin pass should contain at least one spesial character");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", true);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", true),
                options => options.Repeat.Times(0)
            );
        }

        [TestMethod]
        public void VerifyTest_If_Password_contains_At_Least_One_Special_Character_For_Admins_Return_True()
        {
            string pass = "fd3)(&542s13@$#24fsf";
            Result expected = new Result(true, "OK");
            IRepository repository = MockRepository.GenerateMock<IRepository>();
            PassChecker pc = new PassChecker(repository);
            Result actual = pc.Verify(pass, "user", true);
            Debug.WriteLine(actual.Mess);
            Assert.AreEqual(expected, actual);
            repository.AssertWasCalled(
                example => example.CreateUser(pass, "user", true),
                options => options.Repeat.Times(1)
            );
        }
    }
}
