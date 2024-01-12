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

    // 음표 간격 및 크기 조절을 위한 변수
    private const float NoteSpacing = 10f; // 음표 간격 
    private const float NoteHeight = 20f;  // 음표 높이 
    private const float NoteWidth = 20f;   // 음표 너비

    // 음표를 그릴 때 사용할 텍스처
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
        // 음표 그리기
        // 음표 번호를 기반으로 위치 계산 로직 작성해야 함.
        //  Unity의 GUI함수 사용해서 그려야 될 듯
        // 음표를 그릴 위치 계산
        float x = StartTime * NoteSpacing; // 노트 간격을 곱해줘서 시간을 픽셀로 변환
        float y = NoteNumber * NoteHeight; // 음표 번호에 따라 높이 조절

        // 음표를 그리는 코드
        GUI.DrawTexture(new Rect(x, y, NoteWidth, NoteHeight), noteTexture);

    }
}
