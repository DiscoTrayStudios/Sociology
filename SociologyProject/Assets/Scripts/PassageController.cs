using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class PassageController : MonoBehaviour
{
    string[] chunks;
    int currentIndex;

    public delegate void ChunkEnteredHandler(string chunk);
    public event ChunkEnteredHandler onEnteredChunk;
    
    public string GetCurrentChunk()
    {
        return chunks[currentIndex];
        
    }

    public bool IsEndOfPassagage()
    {
        return currentIndex == chunks.Length-1;
    }

    public void InitializePassage(Node node)
    {
        chunks = node.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        //Debug.Log("******");
        //foreach(string t in chunks)
        //{
        //    Debug.Log(t);
        //}
        
        //Debug.Log("***");
        currentIndex = 0;
        onEnteredChunk(chunks[currentIndex]);
    }

    public void Next()
    {
        string nextChunk = chunks[++currentIndex];
        //Debug.Log(nextChunk);
        onEnteredChunk(nextChunk);
    }
}