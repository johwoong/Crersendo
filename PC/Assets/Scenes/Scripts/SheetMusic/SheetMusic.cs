using SmfLite;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SheetMusic
{
    private List<Staff> staffs; 
    public SheetMusic()
    {
        staffs = new List<Staff>();
    }

    void OnGUI(Graphics g)
    {
        // ȭ�鿡 �Ǻ� �׸���
        foreach (var staff in staffs)
        {
            staff.Draw(g);
        }
    }


    public void AddSymbolsFromMIDI(MidiTrack track)
    {
        var staff = new Staff();

        foreach (var deltaEventPair in track.sequence)
        {
            var midiEvent = deltaEventPair.midiEvent;

            if ((midiEvent.status & 0xF0) == 0x90) // Note On �̺�Ʈ
            {
                // ��ǥ ���� ����
                int noteNumber = midiEvent.data1;
                int velocity = midiEvent.data2;

                // Note ��ȣ ����
                var note = new Note
                {
                    NoteNumber = noteNumber,
                    Velocity = velocity,
                    StartTime = staff.CurrentTime,
                    Duration = deltaEventPair.delta
                };

                // Note�� Staff�� �߰�
                staff.AddSymbol(note);
            }
            else if ((midiEvent.status & 0xF0) == 0x80) // Note Off �̺�Ʈ
            {
                // ��ǥ ���� ����
                int noteNumber = midiEvent.data1;

                // Staff���� �ش��ϴ� Note ã�Ƽ� ���� �ð� ����
                var note = staff.FindNoteByNoteNumber(noteNumber);
                if (note != null)
                {
                    note.EndTime = staff.CurrentTime;
                }
            }
            else
            {
                // �ٸ� MIDI �̺�Ʈ ó��
                // ���� ���� ����
            }

            // Staff�� ���� �ð� ������Ʈ
            staff.CurrentTime += deltaEventPair.delta;
        }

        // Staff�� SheetMusic�� �߰�
        staffs.Add(staff);
    }

}
