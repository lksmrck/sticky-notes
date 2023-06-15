import TextareaAutosize from "@mui/base/TextareaAutosize";
import { FC } from "react";

type Props = {
  name: string;
  id: string;
  onChange: (e: any) => void;
};

const TextArea: FC<Props> = ({ name, id, onChange }) => {
  return (
    <TextareaAutosize
      aria-label="minimum height"
      id={id}
      name={name}
      minRows={3}
      placeholder="Minimum 3 rows"
      className=" shadow appearance-none border focus:border-blue-600 rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
      onChange={onChange}
    />
  );
};

export default TextArea;
