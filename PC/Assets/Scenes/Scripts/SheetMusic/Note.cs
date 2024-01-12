using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class Note : Symbol
{
    public int NoteNumber { get; set; }
    public int Velocity { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }

    // ��ǥ ���� �� ũ�� ������ ���� ����
    private const float NoteSpacing = 10f; // ��ǥ ���� 
    private const float NoteHeight = 20f;  // ��ǥ ���� 
    private const float NoteWidth = 20f;   // ��ǥ �ʺ�

    // ��ǥ�� �׸� �� ����� �ؽ�ó
    public Texture2D noteTexture;

    public int Duration
    {
        get => EndTime - StartTime;
        set
        {
            EndTime = StartTime + value;
        }
    }

    public override void Draw(Graphics g)
    {
        // ��ǥ �׸���
        // ��ǥ ��ȣ�� ������� ��ġ ��� ���� �ۼ��ؾ� ��.
        //  Unity�� GUI�Լ� ����ؼ� �׷��� �� ��
        // ��ǥ�� �׸� ��ġ ���
        float x = StartTime * NoteSpacing; // ��Ʈ ������ �����༭ �ð��� �ȼ��� ��ȯ
        float y = NoteNumber * NoteHeight; // ��ǥ ��ȣ�� ���� ���� ����

        // ��ǥ�� �׸��� �ڵ�
        GUI.DrawTexture(new Rect(x, y, NoteWidth, NoteHeight), noteTexture);

    }
}
