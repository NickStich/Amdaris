import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invoice } from 'src/app/model/invoice/invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private invoiceUrl: string;

  constructor(private http: HttpClient) {
    this.invoiceUrl = 'https://localhost:44380/inv';
  }

  public findAll(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.invoiceUrl + '/GetAll');
  }

  public save(invoice: Invoice) {
    return this.http.post<Invoice>(this.invoiceUrl + '/Create', invoice);
  }

  public update(invoiceId: number, invoice: Invoice) {
    return this.http.put(this.invoiceUrl + '/Update/' + invoiceId, invoice);
  }

  public delete(invoiceId: number) {
    return this.http.delete(this.invoiceUrl + '/Delete/' + invoiceId);
  }

  public getById(invoiceId: number) {
    return this.http.get<Invoice>(this.invoiceUrl + '/GetById/' + invoiceId);
  }
}
