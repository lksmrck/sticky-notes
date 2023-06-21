import { useState } from "react";
import TextArea from "../TextArea";
import TagsInput from "./TagsInput";
import { NoteType } from "../../types";
import { createNote } from "../../api";
import useAuth from "../../context/AuthContext";

const Form = () => {
  const { currentUser } = useAuth();
  const [formData, setFormData] = useState<NoteType>({
    author: currentUser.user.name,
  } as NoteType);

  const handleSubmit = async (e: any): Promise<void> => {
    e.preventDefault();
    const res = await createNote(formData, currentUser.token);
    console.log(res);
  };

  const inputChangeHandler = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const liftTagsStateUp = (tags: string[]): void => {
    setFormData({ ...formData, tags: tags });
  };

  const keyPress = (e: any) => {
    // If enter is pressed
    if (e.keyCode == 13) {
      e.preventDefault();
    }
  };

  return (
    <div className="w-full h-full flex justify-center items-center ">
      <form
        className="  bg-teal-100 w-1/3 shadow-md rounded-xl px-8 pt-6 pb-8 mb-4 min-h-1/2"
        onSubmit={handleSubmit}
      >
        <div className="mb-4">
          <label
            className="block text-gray-700 text-sm font-bold mb-2"
            htmlFor="heading"
            onKeyDown={keyPress}
          >
            Heading
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="heading"
            name="heading"
            type="text"
            placeholder="Heading"
            onChange={inputChangeHandler}
          />
        </div>
        <div className="mb-6">
          <label
            className="block text-gray-700 text-sm font-bold mb-2"
            htmlFor="text"
          >
            Text
          </label>
          <TextArea name="text" id="text" onChange={inputChangeHandler} />
          <TagsInput liftTagsStateUp={liftTagsStateUp} />
        </div>
        <div className="flex items-center justify-center [&>*]:m-2">
          <button
            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            type="submit"
          >
            Submit
          </button>

          <a
            className="inline-block align-baseline font-bold text-sm text-blue-500 hover:text-blue-800"
            href="#"
          >
            Discard Changes
          </a>
        </div>
      </form>
    </div>
  );
};

export default Form;
