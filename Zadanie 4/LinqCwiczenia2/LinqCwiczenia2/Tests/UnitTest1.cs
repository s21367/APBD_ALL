using LinqTutorials;
using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {

        #region Init
        public static IEnumerable<Emp> EmpsTest { get; set; }
        public static IEnumerable<Dept> DeptsTest { get; set; }

        public static int[] Array = { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 10, 2, 10, 10 };

        public UnitTest1()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();


            #region Load depts

            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            var d4 = new Dept
            {
                Deptno = 5,
                Dname = "Accounting",
                Loc = "Radom"
            };

            var d5 = new Dept
            {
                Deptno = 2137,
                Dname = "Testing",
                Loc = "Wadowice"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            deptsCol.Add(d4);
            deptsCol.Add(d5);
            DeptsTest = deptsCol;

            #endregion

            #region Load emps

            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-1),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            var e12 = new Emp
            {
                Deptno = 5,
                Empno = 100,
                Ename = "Marcin Marcinowski",
                HireDate = DateTime.Now.AddMonths(-10),
                Job = "KING",
                Mgr = null,
                Salary = 50000
            };

            var e11 = new Emp
            {
                Deptno = 5,
                Empno = 10,
                Ename = "Kunta Kinte",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Backend programmer",
                Mgr = e12,
                Salary = 2000
            };


            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            empsCol.Add(e11);
            empsCol.Add(e12);

            EmpsTest = empsCol;

            #endregion



            LinqTasks.Emps = EmpsTest;
            LinqTasks.Depts = DeptsTest;

        }


        #endregion


      

        [Fact]
        public void Task1_Test()
        {
            IEnumerable<Emp> studRes = LinqTasks.Task1()?.ToList();

            Assert.NotNull(studRes);
            Assert.Equal(3, studRes.Count());
        }

       

        [Fact]
        public void Task2_Test()
        {
            IEnumerable<Emp> studRes = LinqTasks.Task2()?.ToList();

            Assert.NotNull(studRes);
            Assert.Equal(3, studRes.Count());

            List<Emp> myRes = EmpsTest.Where(x => x.Empno == 1 || x.Empno == 2 || x.Empno == 20).ToList();
            foreach (var myEmp in myRes)
            {
                Assert.Contains(myEmp, studRes);
            }
        }


        

        [Fact]
        public void Task3_Test()
        {
            int studRes = LinqTasks.Task3();

            Assert.True(studRes > 0);
            Assert.Equal(50000, studRes);
        }


        

        [Fact]
        public void Task4_Test()
        {
            IEnumerable<Emp> studRes = LinqTasks.Task4()?.ToList();

            Assert.NotNull(studRes);
            Assert.Single(studRes);

            List<Emp> myRes = EmpsTest.Where(x => x.Empno == 100).ToList();
            foreach (var myEmp in myRes)
            {
                Assert.Contains(myEmp, studRes);
            }
        }


        

        [Fact]
        public void Task5_Test()
        {
            IEnumerable<object> studRes = LinqTasks.Task5()?.ToList();

            Assert.NotNull(studRes);
            Assert.Equal(12, studRes.Count());

            var firstEmp = studRes.First();
            Assert.True(firstEmp.ToString().Equals(new { Nazwisko = "Jan Kowalski", Praca = "Frontend programmer" }.ToString()));

        }

       

        [Fact]
        public void Task6_Test()
        {
            IEnumerable<object> studRes = LinqTasks.Task6()?.ToList();

            Assert.NotNull(studRes);
            Assert.True(studRes.Last().ToString().Equals(new { Ename = "Marcin Marcinowski", Job = "KING", Dname = "Accounting" }.ToString()));
        }


        

        [Fact]
        public void Task7_Test()
        {
            IEnumerable<object> studRes = LinqTasks.Task7()?.ToList();

            Assert.NotNull(studRes);
            Assert.Equal(8, studRes.Count());
            Assert.True(studRes.First().ToString().Equals(new { Praca = "Frontend programmer", LiczbaPracownikow = 3 }.ToString()));
            Assert.True(studRes.Last().ToString().Equals(new { Praca = "KING", LiczbaPracownikow = 1 }.ToString()));
        }

       

        [Fact]
        public void Task8_Test()
        {
            bool studRes = LinqTasks.Task8();

            Assert.True(studRes);
        }

       

        [Fact]
        public void Task9_Test()
        {
            Emp studRes = LinqTasks.Task9();

            Assert.NotNull(studRes);
            Assert.Equal("Jan Kowalski", studRes.Ename);
            Assert.Equal(1, studRes.Empno);
        }

        

        [Fact]
        public void Task10_Test()
        {
            IEnumerable<object> studRes = LinqTasks.Task10()?.ToList();

            Assert.NotNull(studRes);

            var kingHiredate = EmpsTest.First(x => x.Job == "KING").HireDate;

            Assert.Equal(13, studRes.Count());
            Assert.True(studRes.ElementAt(11).ToString().Equals(new { Ename = "Marcin Marcinowski", Job = "KING", HireDate = kingHiredate }.ToString()));
            Assert.True(studRes.Last().ToString().Equals(new { Ename = "Brak wartości", Job = string.Empty, HireDate = (DateTime?)null }.ToString()));

        }

        

        [Fact]
        public void Task11_Test()
        {
            IEnumerable<object> studRes = LinqTasks.Task11()?.ToList();

            Assert.NotNull(studRes);
            Assert.True(studRes.Last().ToString().ToLower().Equals(new { Name = "Accounting", NumOfEmployees = 2 }.ToString().ToLower()));
        }

        

        [Fact]
        public void Task12_Test()
        {
            IEnumerable<Emp> studRes = LinqTasks.Task12()?.ToList();

            Assert.NotNull(studRes);
            Assert.Contains(studRes, x => x.Ename == "Marcin Marcinowski" && x.Empno == 100);

            Assert.Equal("Anna Malewska", studRes.First().Ename);
            Assert.Equal("Marcin Marcinowski", studRes.Last().Ename);

        }

        

        [Fact]
        public void Task13_Test()
        {
            int studRes = LinqTasks.Task13(Array);

            Assert.Equal(2, studRes);
        }

        

        [Fact]
        public void Task14_Test()
        {
            IEnumerable<Dept> studRes = LinqTasks.Task14()?.ToList();

            Assert.NotNull(studRes);
            Assert.Equal(2, studRes.Count());

            Assert.Contains(studRes, x => x.Dname == "Testing" && x.Deptno == 2137);
            Assert.Equal("Testing", studRes.Last().Dname);
        }
    }
}
