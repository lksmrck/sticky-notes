import { FC, FormEvent, useState } from "react";
import { Button, Chip } from "@mui/material";
import Input from "../Input";

type Props = {
  liftTagsStateUp: (tags: string[]) => void;
};

const TagsInput: FC<Props> = ({ liftTagsStateUp }) => {
  const [tags, setTags] = useState(["test"]);
  const [currValue, setCurrValue] = useState("");

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCurrValue(e.target.value);
  };

  const handleDelete = (item: string, index: number) => {
    let arr = [...tags];
    arr.splice(index, 1);
    console.log(item);
    setTags(arr);
    liftTagsStateUp(tags);
  };

  const keyPress = (e: any) => {
    // If enter is pressed
    if (e.keyCode == 13) {
      e.preventDefault();
      setTags((curr) => [...curr, currValue]);
      console.log(tags);
      setCurrValue("");
    }
  };

  return (
    //Container
    <div className="w-full bg-white flex items-center flex-wrap [&>*]:m-1">
      {tags.map((item: any, index: number) => (
        <Chip
          size="small"
          onDelete={() => handleDelete(item, index)}
          label={item}
        />
      ))}
      <div>
        <Input value={currValue} onChange={handleChange} onKeyDown={keyPress} />
        {/* <Button type="submit">Sub</Button> */}
      </div>
    </div>
  );
};

export default TagsInput;
