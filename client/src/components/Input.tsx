import { Input as MUI_Input } from "@mui/material";
import { FC } from "react";

type Props = {
  value: string;
  name?: string;
  onChange: any;
  onKeyDown?: any;
};

const Input: FC<Props> = ({ value, onChange, onKeyDown, name }) => {
  return (
    <MUI_Input
      value={value}
      onChange={onChange}
      onKeyDown={onKeyDown}
      name={name}
    />
  );
};

export default Input;
