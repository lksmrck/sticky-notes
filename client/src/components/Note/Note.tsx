import { FC } from "react";

type Props = {
  heading: string;
  text: string;
};

const Note: FC<Props> = ({ heading, text }) => {
  return (
    <li>
      <div className="note">
        <h2>{heading}</h2>
        <p>{text}</p>
      </div>
    </li>
  );
};

export default Note;
