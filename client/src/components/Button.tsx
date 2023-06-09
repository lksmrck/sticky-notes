import { Button as MUI_Button } from "@mui/material";
import { FC } from "react";

type Props = {
  blue?: boolean;
  red?: boolean;
  yellow?: boolean;
  onClick?: (e?: any) => void;
  text: string;
};

const Button: FC<Props> = ({ blue, red, onClick, text, yellow }) => {
  const blueStyle =
    "rounded-full border border-blue-950 bg-blue-950 py-1.5 px-5 text-white transition-all hover:bg-slate-900 text-center text-sm  flex items-center justify-center";
  const redStyle =
    "rounded-full border border-red-950 bg-red-950 py-1.5 px-5 text-white transition-all hover:bg-red-800 text-center text-sm  flex items-center justify-center";
  const yellowStyle =
    "rounded-full border border-amber-700 bg-amber-700 py-1.5 px-5 text-white transition-all hover:bg-amber-600 text-center text-sm  flex items-center justify-center";

  return (
    <MUI_Button
      className={`${blue && blueStyle} ${red && redStyle} ${
        yellow && yellowStyle
      }`}
      onClick={onClick}
    >
      {text}
    </MUI_Button>
  );
};

export default Button;
