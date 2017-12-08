using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "New Word Map")]
public class Words : ScriptableObject
{
    //Got words from here: 
    // https://secure.spellingbee.com/sites/default/files/inline-files/010-2017_School_Spelling_Bee_List_2-pager.pdf
    
    [SerializeField] private WordMap[] _wordCountMap = new WordMap[]
    {
        //3 letter words
        new WordMap
        {
            {"cat", "cat definition"},
            {"fit", "fit definition"},
            {"bus", "bus definition"},
            {"job", "job definition"},
            {"row", "row definition"},
            {"aim", "aim definition"}
        },

        //4 letter words
        new WordMap
        {
            {"dots", "dots definition"},
            {"tree", "tree definition"},
            {"room", "room definition"},
            {"meal", "meal definition"},
            {"tile", "tile definition"},
            {"lost", "lost definition"}
        },

        //5 letter words
        new WordMap
        {
            {"sharp", "sharp definition"},
            {"small", "small definition"},
            {"mouse", "mouse definition"},
            {"swift", "swift definition"},
            {"paint", "paint definition"}
        },

        //6 letter words
        new WordMap
        {
            {"rather", "rather definition"},
            {"anyone", "anyone definition"},
            {"bother", "bother definition"},
            {"trance", "trance definition"},
            {"clause", "clause definition"},
            {"hangar", "hangar definition"}
        },

        //7 letter words
        new WordMap
        {
            {"puzzles", "puzzles definition"},
            {"lookout", "lookout definition"},
            {"flicker", "flicker definition"},
            {"observe", "observe definition"},
            {"elderly", "elderly definition"}
        },

        //8 letter words
        new WordMap
        {
            {"backdrop", "backdrop definition"},
            {"stroller", "stroller definition"},
            {"shopping", "shopping definition"},
            {"innocent", "innocent definition"},
            {"saucepan", "saucepan definition"}
        },

        //9 letter words
        new WordMap
        {
            {"semaphore", "semaphore definition"},
            {"tightrope", "tightrope definition"},
            {"mountains", "mountains definition"},
            {"wonderful", "wonderful definition"},
            {"poisonous", "poisonous definition"},
            {"cavalcade", "cavalcade definition"}
        },
        
        //10 letter words
        new WordMap
        {
            {"complaints", "complaints definition"},
            {"dumbwaiter", "dumbwaiter definition"},
            {"unbearable", "unbearable definition"},
            {"marvellous", "marvellous definition"},
            {"hypotenuse", "hypotenuse definition"},
            {"enumerated", "enumerated definition"}
        }
    };

    public KeyValuePair<string, string> GetWord(WordCount wordCount, int index = -1)
    {
        var wordMapIndex = (int) wordCount;
        wordMapIndex = Mathf.Clamp(wordMapIndex, 0, _wordCountMap.Length - 1);

        var wordMapLength = _wordCountMap[wordMapIndex].Count;

        //Check to see if the index is in range
        if (index < 0 || index > wordMapLength)
        {
            //if not select a random word
            index = Random.Range(0, _wordCountMap[wordMapIndex].Count);
        }

        var newWord = _wordCountMap[wordMapIndex].ElementAt(index);
        return newWord;
    }
}
