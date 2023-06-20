export type NoteType = {
  id: number;
  heading: string;
  text: string;
  author: string;
  tags: string[];
};

export type LoginUserType = {
  userName: string;
  password: string;
};
