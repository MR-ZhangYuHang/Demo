using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式
{
    public class FlyweightFactory
    {
        private static Dictionary<WordType, BaseWord> _FlyweightFactoryDictionary = new Dictionary<WordType, BaseWord>();
        private static readonly object FlyweightFactoryLock = new object();
        public static BaseWord GetWord(WordType wordType)
        {
            if (!_FlyweightFactoryDictionary.ContainsKey(wordType))
            {
                lock (FlyweightFactoryLock)//可以保证只有一个线程尽进来
                {
                    if (!_FlyweightFactoryDictionary.ContainsKey(wordType))
                    {
                        BaseWord baseWord = null;
                        switch (wordType)
                        {
                            case WordType.E:
                                baseWord = new E();
                                break;
                            case WordType.L:
                                baseWord = new L();
                                break;
                            case WordType.V:
                                baseWord = new V();
                                break;
                            case WordType.N:
                                baseWord = new N();
                                break;
                            default:
                                throw new Exception("wrong wordType");
                        }
                        _FlyweightFactoryDictionary.Add(wordType, baseWord);
                    }
                }
            }
            return _FlyweightFactoryDictionary[wordType];
        }

        public enum WordType
        {
            E,
            L,
            V,
            N
        }
    }
}
