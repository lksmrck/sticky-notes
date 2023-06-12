import { useState } from "react";
import { Chip } from "@mui/material";
import Input from "../Input";

const TagsInput = () => {
  const [tags, setTags] = useState(["test"]);
  const [currValue, setCurrValue] = useState("");

  const handleChange = (e: any) => {
    setCurrValue(e.target.value);
  };

  const handleDelete = (item: any, index: number) => {
    let arr = [...tags];
    arr.splice(index, 1);
    console.log(item);
    setTags(arr);
  };

  return (
    //Container
    <div className="w-full bg-white flex items-center [&>*]:m-1">
      {tags.map((item: any, index: number) => (
        <Chip
          size="small"
          onDelete={() => handleDelete(item, index)}
          label={item}
        />
      ))}
      <Input value={currValue} onChange={handleChange} />
    </div>
  );
};

export default TagsInput;
