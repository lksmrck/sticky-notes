import "./style.css";
import Note from "./Note";
import { useEffect, useState } from "react";
import { NoteType } from "../../types";
import { getNotes } from "../../api";
import useAuth from "../../context/AuthContext";

const NoteList = () => {
  const [notes, setNotes] = useState<NoteType[] | null>(null);
  const { currentUser } = useAuth();

  useEffect(() => {
    console.log(currentUser.token);
    const fetchData = async () => {
      const data = await getNotes(currentUser.token);

      setNotes(data);
    };

    fetchData();
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
