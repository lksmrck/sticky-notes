import "./style.css";
import Note from "./Note";
import { useEffect, useState } from "react";
import { NoteType } from "../../types";
import { getNotes } from "../../api";
import useAuth from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const NoteList = () => {
  const [notes, setNotes] = useState<NoteType[] | null>(null);
  const { currentUser } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getNotes(currentUser.token);

        setNotes(data);
      } catch (error) {
        navigate("/error");
      }
    };

    fetchData();
  }, []);

  return (
    <ul>
      {notes &&
        notes.map((note: NoteType) => (
          <Note
            heading={note.heading}
            text={note.text}
            id={note.id}
            tags={note.tags}
          />
        ))}
    </ul>
  );
};

export default NoteList;
