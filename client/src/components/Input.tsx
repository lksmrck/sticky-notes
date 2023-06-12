import { Input as MUI_Input } from "@mui/material";
import { FC } from "react";

type Props = {
  value: string;
  onChange: any;
};

const Input: FC<Props> = ({ value, onChange }) => {
  return <MUI_Input value={value} onChange={onChange} />;
};

export default Input;
