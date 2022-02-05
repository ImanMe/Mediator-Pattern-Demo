export interface IToDo {
    id: number;
    createdDate: string;
    description: string;
    isCompleted: boolean;
}

export class ToDo implements IToDo {
    constructor(
        public id: number = 0,
        public createdDate: string = '',
        public description: string = '',
        public isCompleted: boolean = false) {
    }
}