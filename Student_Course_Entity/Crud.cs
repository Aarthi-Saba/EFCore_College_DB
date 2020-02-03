using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Student_Course_Entity
{
    public class Crud<T> where T : class
    {
        private readonly HumberContext _context;
        public Crud()
        {
            _context = new HumberContext();
        }
        public void Add(params T[] items)
        {
            foreach(T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }
        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> joinQuery = _context.Set<T>();
            foreach (Expression<Func<T, object>> property in navigationProperties)
            {
                joinQuery = joinQuery.Include<T, object>(property);
            }
            
            return joinQuery.Where(where).FirstOrDefault();
        }
        public IList<T> GetAll(Expression<Func<T,bool>> where)
        {
            return _context.Set<T>().Where(where).ToList<T>();
        }
        
        public void Remove(params T [] pocos)
        {
            foreach(var poco in pocos)
            {
                _context.Entry(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
        public void Update(params T [] pocos)
        {
            foreach(var poco in pocos)
            {
                _context.Entry(poco).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
        public void GetAverageScore(Guid CourseId)
        {
            var scores = _context.Grades.Where(g => g.Course == CourseId).Average(g=>g.SubScore);
            string CourseName = _context.Courses.Where(c => c.CourseId == CourseId).Select(c=> c.CourseName).FirstOrDefault();
            Console.WriteLine($"Average Score of {CourseName} is : {scores}");
        }
    }
}
