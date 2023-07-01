import { useState } from "react";
import TextArea from "../TextArea";
import TagsInput from "./TagsInput";
import { NoteType } from "../../types";
import { createNote } from "../../api";
import useAuth from "../../context/AuthContext";
import Button from "../Button";

const Form = () => {
  const { currentUser } = useAuth();
  const [formData, setFormData] = useState<NoteType>({} as NoteType);

  const handleSubmit = async (e: any): Promise<void> => {
    e.preventDefault();
    const res = await createNote(
      { ...formData, author: currentUser.user.name },
      currentUser.token
    );
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
        className=" bg-sky-950 w-1/3 shadow-md rounded-xl px-8 pt-6 pb-8 mb-4 min-h-1/2"
        onSubmit={handleSubmit}
      >
        <div className="mb-4">
          <label
            className="block  text-sm font-bold mb-2 text-white"
            htmlFor="heading"
            onKeyDown={keyPress}
          >
            Note Heading
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3  leading-tight focus:outline-none focus:shadow-outline"
            id="heading"
            name="heading"
            value={formData.heading}
            type="text"
            placeholder="Heading"
            onChange={inputChangeHandler}
          />
        </div>
        <div className="mb-6">
          <label
            className="block text-white text-sm font-bold mb-2"
            htmlFor="text"
          >
            Note Text
          </label>
          <TextArea
            name="text"
            id="text"
            onChange={inputChangeHandler}
            value={formData.text}
          />
          <TagsInput liftTagsStateUp={liftTagsStateUp} value={formData.tags} />
        </div>
        <div className="flex items-center justify-center [&>*]:m-2">
          <Button text="Submit" yellow={true} />

          <button
            className="inline-block align-baseline font-bold text-sm text-red-700 hover:text-red-600"
            onClick={() => setFormData(emptyForm as NoteType)}
            type="button"
          >
            Discard Changes
          </button>
        </div>
      </form>
    </div>
  );
};

export default Form;

const emptyForm = { heading: "", text: "" /* tags: [""] */ };
