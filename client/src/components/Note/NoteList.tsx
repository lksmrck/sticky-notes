import "./style.css";
import Note from "./Note";
import { useEffect, useState } from "react";
import { NoteType } from "../../types";

const NoteList = () => {
  const [notes, setNotes] = useState<NoteType[] | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch("https://localhost:7280/api/NoteAPI");
      const data = await response.json();
      setNotes(data.result);
      // console.log(data);
    };

    fetchData();
  }, []);

  return (
    <ul>
      {notes &&
        notes.map((note: NoteType) => (
          <Note heading={note.heading} text={note.text} />
        ))}
    </ul>
  );
};

export default NoteList;
