using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _radom = Random.Range(0, 4); // ���, Ǯ���, �θ���, �ȱ�


        if (_radom == 0)
            Wait();
        else if (_radom == 1)
            Eat();
        else if (_radom == 2)
            Peek();
        else if (_radom == 3)
            TryWalk();
    }

    private void Wait()
    {
        currentTime = waitTime;
        Debug.Log("���");
    }
    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
        Debug.Log("Ǯ���");
    }
    private void Peek()
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
        Debug.Log("�θ���");
    }
}

