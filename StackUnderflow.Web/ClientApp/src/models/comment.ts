export interface comment {
  id: number;
  text: string;
  commentedBy: string;
  commentedAt: any;
  isSolution: boolean;
  votes: number;
  questionId: number;
}
