using System;
using Xunit;
using System.Collections.Generic;

namespace Collections.Test
{
    public class CollectionTests
    {
        [Fact]
        public void HashSetValuesSameAsArray()
        {
            // HashSet<Employee> set = new HashSet<Employee>() { new Employee {Name = "Maike"}, new Employee {Name = "Shane"}};
            // Employee[] array = new Employee[] {new Employee {Name = "Maike"}, new Employee {Name = "Shane"}};

            // HashSet<int> set1 = new HashSet<int>() {1, 2, 3};
            // // Assert.IsTrue(set.SetEquals(array));
            // Assert.IsTrue(set1.SetEquals(new[] {1, 2, 3}));
            var set1 = new HashSet<int>() {1, 2, 3};
            var set2 = new HashSet<int>() {2, 3, 4};

            set1.SymmetricExceptWith(set2);
            
            var set3 = new[] {1, 4};

            Assert.Equal(set1, set3);
            Assert.Equal(set1, new[] {1,4});

        }
    }
}
