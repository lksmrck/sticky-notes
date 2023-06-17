import "./style.css";
import Note from "./Note";
import { useEffect, useState } from "react";
import { NoteType } from "../../types";
import { getNotes } from "../../api";

const NoteList = () => {
  const [notes, setNotes] = useState<NoteType[] | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      const data = await getNotes();
      setNotes(data);
    };

    fetchData();
    console.log(notes);
  }, []);

  return (
    <ul>
      {notes &&
        notes.map((note: NoteType) => (
          <Note heading={note.heading} text={note.text} id={note.id} />
        ))}
    </ul>
  );
};

export default NoteList;
