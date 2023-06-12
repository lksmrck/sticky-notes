import React from "react";
import TextArea from "../TextArea";
import TagsInput from "./TagsInput";

const Form = () => {
  return (
    <div className="w-full  h-full flex justify-center items-center ">
      <form className=" bg-teal-100 w-1/3 shadow-md rounded-xl px-8 pt-6 pb-8 mb-4 h-1/2">
        <div className="mb-4">
          <label
            className="block text-gray-700 text-sm font-bold mb-2"
            htmlFor="heading"
          >
            Heading
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="heading"
            type="text"
            placeholder="Heading"
          />
        </div>
        <div className="mb-6">
          <label
            className="block text-gray-700 text-sm font-bold mb-2"
            htmlFor="text"
          >
            Text
          </label>
          <TextArea />
          <TagsInput />
        </div>
        <div className="flex items-center justify-center [&>*]:m-2">
          <button
            className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            type="button"
          >
            Save Note
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
