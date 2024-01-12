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
        // �־��� ��ǥ ��ȣ�� ��ġ�ϴ� symbols ��Ͽ��� ù ��° Note ã��
        return symbols.Find(symbol => symbol is Note note && note.NoteNumber == noteNumber) as Note;
    }

    public void Draw(Graphics g)
    {
        // S��ǥ �׸���
        foreach (var symbol in symbols)
        {
            symbol.Draw(g);
        }
    }
}
