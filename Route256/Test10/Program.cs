using System;
using System.Collections.Generic;
using System.Linq;

namespace Test10;

public class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        TreeSuf tree = new();
        tree.leaf = '0';
        tree.childrens = new List<TreeSuf>();
        tree.words = new List<string>();

        for (int i = 0; i < number; i++)
        {
            string word = Console.ReadLine();

            tree.words.Add(word);
            TreeSuf tmp = tree;
            
            for (int j = word.Length - 1; j >= 0; j--)
            {
                List<TreeSuf> child = tmp.childrens.Where(c => c.leaf == word[j]).ToList();

                if (!child.Any())
                {
                    tmp.childrens.Add(new TreeSuf
                    {
                        childrens = new(),
                        leaf = word[j],
                        words = new List<string> { word }
                    });

                    tmp = tmp.childrens[tmp.childrens.Count - 1];

                    continue;
                }

                tmp = child[0];
                tmp.words.Add(word);
            }

            if (tmp.childrens is null)
            {
                tmp.childrens = new List<TreeSuf>
                    {
                        new TreeSuf
                        {
                            childrens = new(),
                            leaf = '.'
                        }
                    };
            }
            else
            {
                tmp.childrens.Add(new TreeSuf
                {
                    leaf = '.'
                });
            }
        }

        int value = int.Parse(Console.ReadLine());

        for (int i = 0; i < value; i++)
        {
            string word = Console.ReadLine();

            TreeSuf tmp = tree;

            int j = 1;
            for (j = word.Length - 1; j >= 0; j--)
            {
                List<TreeSuf> child = tmp.childrens.Where(c => c.leaf == word[j]).ToList();

                if (child.Count == 0)
                {
                    Console.WriteLine(tmp.words[0]);

                    break;
                }

                if (child[0].words.Count == 1)
                {
                    if (child[0].words[0].Equals(word))
                    {
                        Console.WriteLine(tmp.words.Where(w => !w.Equals(word)).FirstOrDefault());
                    }
                    else
                    {
                        Console.WriteLine(child[0].words[0]);
                    }

                    break;
                }

                tmp = child[0];
            }

            if (j == -1)
            {
                Console.WriteLine(tmp.words.Where(w => !w.Equals(word)).FirstOrDefault());
            }
        }

    }

    public struct TreeSuf
    {
        public char leaf;
        public List<TreeSuf> childrens;
        public List<string> words;
    }
}