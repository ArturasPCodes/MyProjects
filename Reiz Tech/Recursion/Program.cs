namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var branch = GetComplexBranch();
            var depthLevel = GetMaxDepth(branch);

            Console.WriteLine($"Depth level: " + (depthLevel));
        }

        private static int GetMaxDepth(Branch branch, int depth = 1)
        {
            if (branch == null)
            {
                return 0;
            }

            if (branch.Branches == null)
            {
                return depth;
            }

            int maxDepth = depth;

            foreach (var insideBranch in branch.Branches)
            {
                var insideBranchDepth = GetMaxDepth(insideBranch, depth + 1);

                if (maxDepth < insideBranchDepth)
                {
                    maxDepth = insideBranchDepth;
                }
            }

            return maxDepth;
        }

        private static Branch GetComplexBranch()
        {
            return new Branch()
            {
                Branches = new List<Branch>()
                {
                    //1.1
                    new Branch()
                    {
                        Branches = new List<Branch>()
                        {
                            //1.1.1
                            new Branch()
                        }
                    },

                    //1.2
                    new Branch()
                    {
                        Branches = new List<Branch>()
                        {
                            //1.2.1
                            new Branch()
                            {
                                Branches = new List<Branch>()
                                {
                                    //1.2.1.1
                                    new Branch()
                                }
                            },

                            //1.2.2
                            new Branch()
                            {
                                Branches = new List<Branch>()
                                {
                                    //1.2.2.1
                                    new Branch()
                                    {
                                        Branches = new List<Branch>()
                                        {
                                            //1.2.2.1.1
                                            new Branch()
                                        }
                                    },
                                    //1.2.2.2
                                    new Branch()
                                }
                            }
                        }
                    },

                    //1.3
                    new Branch()
                    {
                        Branches = new List<Branch>() 
                        {
                            //1.3.1
                            new Branch()
                            {
                                Branches = new List<Branch>()
                                {
                                    //1.3.1.1
                                    new Branch()
                                    {
                                        Branches = new List<Branch>()
                                        {
                                            //1.3.1.1.1
                                            new Branch()
                                            {
                                                Branches = new List<Branch>()
                                                {
                                                    //1.3.1.1.1.1
                                                    new Branch()
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}