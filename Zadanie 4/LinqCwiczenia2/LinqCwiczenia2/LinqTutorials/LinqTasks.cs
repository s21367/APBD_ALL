using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorials
{
    public static class LinqTasks
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        static LinqTasks()
        {
            List<Emp> empsCol = new();
            List<Dept> deptsCol = new();

            #region Load depts

            Dept d1 = new()
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            Dept d2 = new()
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            Dept d3 = new()
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;

            #endregion

            #region Load emps

            Emp e1 = new()
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            Emp e2 = new()
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            Emp e3 = new()
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            Emp e4 = new()
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e5 = new()
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e6 = new()
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            Emp e7 = new()
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            Emp e8 = new()
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            Emp e9 = new()
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            Emp e10 = new()
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
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
            Emps = empsCol;

            #endregion
        }


        public static IEnumerable<Emp> Task1()
        {
            IEnumerable<Emp> query = from e in Emps
                                     where e.Job == "Backend programmer"
                                     select e;
            return query;

        }


        public static IEnumerable<Emp> Task2()
        {
            IEnumerable<Emp> query = from e in Emps
                                     where e.Job == "Frontend programmer" && e.Salary > 1000
                                     orderby e.Ename descending
                                     select e;
            return query;
        }



        public static int Task3()
        {
            int res = Emps.Max(s => s.Salary);
            return res;
        }


        public static IEnumerable<Emp> Task4()
        {
            IEnumerable<Emp> query = from e in Emps
                                     where e.Salary == Emps.Max(s => s.Salary)
                                     orderby e.Ename descending
                                     select e;
            return query;
        }


        public static IEnumerable<object> Task5()
        {
            IEnumerable<object> query = from e in Emps
                                        select new { Nazwisko = e.Ename, Praca = e.Job };
            return query;
        }


        public static IEnumerable<object> Task6()
        {
            var query = from e in Emps
                        join d in Depts
                        on e.Deptno equals d.Deptno
                        select new { e.Ename, e.Job, d.Dname };
            return query;
        }

        public static IEnumerable<object> Task99()
        {
            var methodSyntax = Emps.Join(
            Depts,
            e => e.Deptno,
            d => d.Deptno,
            (e, d) => new { e.Ename, e.Job, d.Dname }
            );
            return methodSyntax;
        }


        public static IEnumerable<object> Task7()
        {
            var query = from e in Emps
                        group e by e.Job
                        into g
                        select new { Praca = g.Key, LiczbaPracownikow = g.Count() };
            return query;
        }


        public static bool Task8()
        {
            int numberOfBackendProgrammers = Emps.Count(s => s.Job == "Backend programmer");

            return numberOfBackendProgrammers > 0 ? true : false;
        }


        public static Emp Task9()
        {
            IOrderedEnumerable<Emp> query = from e in Emps
                                            where e.Job == "Frontend programmer"
                                            orderby e.HireDate descending
                                            select e;
            return query.First();
        }


        public static IEnumerable<object> Task10()
        {
            var query = from e in Emps
                        select new { e.Ename, e.Job, e.HireDate };
            IEnumerable<Emp> tempQuery = new List<Emp> {new Emp{
                Deptno = 1,
                Empno = 1,
                Ename = "Brak wartości",
                HireDate = null,
                Job = null,
                Mgr = null,
                Salary = 2000
            } };
            var query2 = from e in tempQuery
                         select new { e.Ename, e.Job, e.HireDate };
            return query.Distinct().Union(query2.Distinct());



        }

        public static IEnumerable<object> Task11()
        {
            var result = Emps
                .Join(Depts, e => e.Deptno, d => d.Deptno, (e, d) => new { d.Dname, e.Empno })
                .GroupBy(d => d.Dname)
                .Select(val => new { name = val.Key, numOfEmployees = val.Count() })
                .Where(val => val.numOfEmployees > 1)
                .ToList();

            return result;
        }


        public static IEnumerable<Emp> Task12()
        {
            return Emps.GetEmpsWithSubordinates().ToList();
        }


        public static int Task13(int[] arr)
        {
            int res = arr.ToList()
                .GroupBy(val => val.GetHashCode())
                .Select(val => new { Value = val.Key, Times = val.Count() })
                .Where(val => (val.Times % 2) != 0)
                .Select(val => val.Value).First();

            return res;
        }


        public static IEnumerable<Dept> Task14()
        {
            IEnumerable<Dept> query = Depts.GroupJoin(Emps, d => d.Deptno, e => e.Deptno, (d, e) => new
            {
                Departament = d,
                Counter = e.Count()
            }).Where(val => val.Counter == 5 || val.Counter == 0).Select(val => val.Departament).ToList();

            return query;
        }
    }

    public static class CustomExtensionMethods
    {
        public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
        {
            return emps
                .Where(e => e.Mgr != null)
                .Select(e => e.Mgr)
                .Distinct()
                .OrderBy(e => e.Ename)
                .ThenByDescending(e => e.Salary);
        }

    }
}
