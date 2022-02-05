import { ToDo } from './models/toDo';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateItem } from './models/createItem';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient) { }

  getItems = (): Observable<ToDo[]> => this.http.get<ToDo[]>('api/items');

  getItem = (id: number): Observable<ToDo> => this.http.get<ToDo>(`api/items/${id}`);

  createItem = (item: CreateItem) => this.http.post('api/items', item);

  updateItem = (item: CreateItem) => this.http.post('api/items/update', item);

  deleteItem = (id: number) => this.http.delete(`api/items/${id}`);
}
