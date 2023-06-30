import { FC } from "react";

type Props = {
  text: string;
};

const Tag: FC<Props> = ({ text }) => {
  return (
    <div className=" rounded-xl bg-slate-300 min-w-fit p-1 m-0.5 text-sm">
      {text}
    </div>
  );
};

export default Tag;
