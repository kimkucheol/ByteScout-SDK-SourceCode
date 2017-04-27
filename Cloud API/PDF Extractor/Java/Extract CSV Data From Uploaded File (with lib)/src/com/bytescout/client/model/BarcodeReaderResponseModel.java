/*
 * bytescout.io
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2017-04-26T03:53:10Z
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */


package com.bytescout.client.model;

import java.util.Objects;
import com.bytescout.client.model.BarcodeReaderResponseModelBarcodes;
import com.google.gson.annotations.SerializedName;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import java.util.ArrayList;
import java.util.List;

/**
 * BarcodeReaderResponseModel
 */
@javax.annotation.Generated(value = "io.swagger.codegen.languages.JavaClientCodegen", date = "2017-04-26T06:52:34.533Z")
public class BarcodeReaderResponseModel {
  @SerializedName("error")
  private Boolean error = null;

  @SerializedName("status")
  private Integer status = null;

  @SerializedName("name")
  private String name = null;

  @SerializedName("barcodes")
  private List<BarcodeReaderResponseModelBarcodes> barcodes = new ArrayList<BarcodeReaderResponseModelBarcodes>();

  public BarcodeReaderResponseModel error(Boolean error) {
    this.error = error;
    return this;
  }

   /**
   * Get error
   * @return error
  **/
  @ApiModelProperty(example = "null", value = "")
  public Boolean getError() {
    return error;
  }

  public void setError(Boolean error) {
    this.error = error;
  }

  public BarcodeReaderResponseModel status(Integer status) {
    this.status = status;
    return this;
  }

   /**
   * Get status
   * @return status
  **/
  @ApiModelProperty(example = "null", value = "")
  public Integer getStatus() {
    return status;
  }

  public void setStatus(Integer status) {
    this.status = status;
  }

  public BarcodeReaderResponseModel name(String name) {
    this.name = name;
    return this;
  }

   /**
   * Get name
   * @return name
  **/
  @ApiModelProperty(example = "null", value = "")
  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

  public BarcodeReaderResponseModel barcodes(List<BarcodeReaderResponseModelBarcodes> barcodes) {
    this.barcodes = barcodes;
    return this;
  }

  public BarcodeReaderResponseModel addBarcodesItem(BarcodeReaderResponseModelBarcodes barcodesItem) {
    this.barcodes.add(barcodesItem);
    return this;
  }

   /**
   * Get barcodes
   * @return barcodes
  **/
  @ApiModelProperty(example = "null", value = "")
  public List<BarcodeReaderResponseModelBarcodes> getBarcodes() {
    return barcodes;
  }

  public void setBarcodes(List<BarcodeReaderResponseModelBarcodes> barcodes) {
    this.barcodes = barcodes;
  }


  @Override
  public boolean equals(java.lang.Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    BarcodeReaderResponseModel barcodeReaderResponseModel = (BarcodeReaderResponseModel) o;
    return Objects.equals(this.error, barcodeReaderResponseModel.error) &&
        Objects.equals(this.status, barcodeReaderResponseModel.status) &&
        Objects.equals(this.name, barcodeReaderResponseModel.name) &&
        Objects.equals(this.barcodes, barcodeReaderResponseModel.barcodes);
  }

  @Override
  public int hashCode() {
    return Objects.hash(error, status, name, barcodes);
  }


  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class BarcodeReaderResponseModel {\n");
    
    sb.append("    error: ").append(toIndentedString(error)).append("\n");
    sb.append("    status: ").append(toIndentedString(status)).append("\n");
    sb.append("    name: ").append(toIndentedString(name)).append("\n");
    sb.append("    barcodes: ").append(toIndentedString(barcodes)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(java.lang.Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
  
}
