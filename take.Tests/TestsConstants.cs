using System.Collections.Generic;

using take.Models;

namespace take.Tests
{
    public static class TestsConstants
    {
        public static List<Repository> FakeRepositories = new List<Repository>
            {
                new Repository()
                {
                    Name = "1 C#",
                    Language = "C#",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undeefined"
                    }
                },

                new Repository()
                {
                    Name = "Should be ignored",
                    Language = "JavaScript",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undeefined"
                    }
                },

                new Repository()
                {
                    Name = "2 C#",
                    Language = "C#",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "3 C#",
                    Language = "C#",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "Should be ignored",
                    Language = "JavaScript",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "4 C#",
                    Language = "C#",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "C++",
                    Language = "C++",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "Not C#",
                    Language = "Elixir",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                },

                new Repository()
                {
                    Name = "5 C#",
                    Language = "C#",
                    Description = "Description",
                    Owner = new Owner()
                    {
                        Avatar = "undefined"
                    }
                }
            };
    }
}
