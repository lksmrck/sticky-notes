import TextareaAutosize from "@mui/base/TextareaAutosize";

const TextArea = () => {
  return (
    <TextareaAutosize
      aria-label="minimum height"
      minRows={3}
      placeholder="Minimum 3 rows"
      className=" shadow appearance-none border focus:border-blue-600 rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
    />
  );
};

export default TextArea;
