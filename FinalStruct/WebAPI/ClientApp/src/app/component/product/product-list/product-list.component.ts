import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Product } from 'src/app/model/product/product';
import { ProductService } from 'src/app/service/productService/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

   products: Product[] = [];
   dataSource = new MatTableDataSource<Product>();
   displayedColumns = ['id', 'name', 'price', 'action'];
   @ViewChild(MatSort, { static: true }) sort: MatSort;
   @ViewChild(MatPaginator , {static: true}) paginator: MatPaginator;

   constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.findAll().subscribe(data => {
      this.products = data ;
      this.dataSource = new MatTableDataSource(this.products);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  deleteClick(productId) {
    this.productService.delete(productId).subscribe();
    this.refreshPage();
  }

  refreshPage() {
    window.location.reload();
  }

  applyFilter(event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
