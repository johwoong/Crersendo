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
        // 화면에 악보 그리기
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

            if ((midiEvent.status & 0xF0) == 0x90) // Note On 이벤트
            {
                // 음표 정보 추출
                int noteNumber = midiEvent.data1;
                int velocity = midiEvent.data2;

                // Note 기호 생성
                var note = new Note
                {
                    NoteNumber = noteNumber,
                    Velocity = velocity,
                    StartTime = staff.CurrentTime,
                    Duration = deltaEventPair.delta
                };

                // Note를 Staff에 추가
                staff.AddSymbol(note);
            }
            else if ((midiEvent.status & 0xF0) == 0x80) // Note Off 이벤트
            {
                // 음표 정보 추출
                int noteNumber = midiEvent.data1;

                // Staff에서 해당하는 Note 찾아서 종료 시간 설정
                var note = staff.FindNoteByNoteNumber(noteNumber);
                if (note != null)
                {
                    note.EndTime = staff.CurrentTime;
                }
            }
            else
            {
                // 다른 MIDI 이벤트 처리
                // 템포 변경 구현
            }

            // Staff의 현재 시간 업데이트
            staff.CurrentTime += deltaEventPair.delta;
        }

        // Staff를 SheetMusic에 추가
        staffs.Add(staff);
    }

}
