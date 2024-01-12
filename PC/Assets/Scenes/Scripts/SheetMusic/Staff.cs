using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Staff
{
    private List<Symbol> symbols;
    public int CurrentTime { get; set; }

    public Staff()
    {
        symbols = new List<Symbol>();
    }

    public void AddSymbol(Symbol symbol)
    {
        symbols.Add(symbol);
    }

    public Note FindNoteByNoteNumber(int noteNumber)
    {
        // 주어진 음표 번호와 일치하는 symbols 목록에서 첫 번째 Note 찾기
        return symbols.Find(symbol => symbol is Note note && note.NoteNumber == noteNumber) as Note;
    }

    public void Draw(Graphics g)
    {
        // S음표 그리기
        foreach (var symbol in symbols)
        {
            symbol.Draw(g);
        }
    }
}
