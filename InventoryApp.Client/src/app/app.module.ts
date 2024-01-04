import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './common/component/header/header.component';
import { SidebarComponent } from './common/component/sidebar/sidebar.component';
import { FooterComponent } from './common/component/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    CommonModule,
    RouterOutlet,
    HeaderComponent,
    SidebarComponent,
    FooterComponent,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoute
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
