import { TextField as MUI_Input } from "@mui/material";
import { FC } from "react";

type Props = {
  value: string;
  name?: string;
  label: string;
  onChange: any;
  onKeyDown?: any;
  placeholder?: string;
  className?: string;
};

const Input: FC<Props> = ({
  value,
  onChange,
  label,
  onKeyDown,
  name,
  placeholder,
  className,
}) => {
  return (
    <MUI_Input
      label={label}
      variant="filled"
      size="small"
      value={value}
      onChange={onChange}
      onKeyDown={onKeyDown}
      name={name}
      placeholder={placeholder}
      className={`${className}`}
      sx={{
        /*  "& label.Mui-focused": {
          color: "#6c1c6a",
        }, */
        /* "& .MuiInput-underline:after": {
          borderBottomColor: "#6c1c6a",
        }, */
        /* "& .MuiOutlinedInput-root": {
          "&.Mui-focused fieldset": {
            borderColor: "#6c1c6a",
          },
        }, */
        "& .MuiFilledInput-underline:after": {
          borderBottomColor: "#fde68a",
        },
        "& .MuiFilledInput-underline:before": {
          borderBottomColor: "#91a6ad",
        },
        "& .MuiFilledInput-underline:hover": {
          borderBottomColor: "#91a6ad",
        },
        "& .MuiFilledInput-root:hover:not(.Mui-disabled, .Mui-error):before": {
          borderBottomColor: "#fef3c7",
        },
        "& .MuiInputLabel-root": {
          color: "#91a6ad",
        },
        "& .MuiInputLabel-root.Mui-focused": {
          color: "#fde68a",
        },
      }}
    />
  );
};

export default Input;

/* MuiFilledInput-underline */
/* class="MuiInputBase-root MuiFilledInput-root MuiFilledInput-underline MuiInputBase-colorPrimary MuiInputBase-formControl MuiInputBase-sizeSmall css-1ff8729-MuiInputBase-root-MuiFilledInput-root" */
/* class="MuiFormLabel-root MuiInputLabel-root MuiInputLabel-formControl MuiInputLabel-animated MuiInputLabel-sizeSmall MuiInputLabel-filled MuiFormLabel-colorPrimary MuiInputLabel-root MuiInputLabel-formControl MuiInputLabel-animated MuiInputLabel-sizeSmall MuiInputLabel-filled css-1mog9k0-MuiFormLabel-root-MuiInputLabel-root" */
