import { FC } from "react";
import { deleteNote } from "../../api";

type Props = {
  heading: string;
  text: string;
  id: number;
};

const Note: FC<Props> = ({ heading, text, id }) => {
  const deleteButtonClickHandler = async () => {
    const res = await deleteNote(id);
  };

  return (
    <li>
      <div className="note relative">
        <div
          className="absolute right-0 top-0 mr-2"
          onClick={deleteButtonClickHandler}
        >
          X
        </div>
        <h2>{heading}</h2>
        <p>{text}</p>
      </div>
    </li>
  );
};

export default Note;
