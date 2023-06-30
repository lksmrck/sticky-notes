import { NoteType, LoginUserType } from "../types";

const NOTES_URL = "https://localhost:7280/api/NoteAPI/";
const AUTH_URL = "https://localhost:7280/api/Users/";

export const getNotes = async (token: string): Promise<NoteType[]> => {
  const res = await fetch(NOTES_URL, {
    headers: {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    },
  });
  const data = await res.json();
  return data.result;
};

export const getNote = () => {};

export const createNote = async (note: NoteType, token: string) => {
  console.log(token);
  const res = await fetch(NOTES_URL, {
    method: "POST",
    headers: {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    },
    body: JSON.stringify(note),
  });

  const data = await res.json();
  return data.result;
};

export const deleteNote = async (id: number) => {
  const res = await fetch(NOTES_URL + id, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
  });
};

// AUTH

export const registerUser = async () => {};

export const loginUser = async (user: LoginUserType) => {
  const res = await fetch(AUTH_URL + "login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });

  const data = await res.json();

  return data.result;
};
