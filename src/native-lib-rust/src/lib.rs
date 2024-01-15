use std::ffi::CStr;
use std::str;

#[no_mangle]
pub extern "C" fn helloworld() {
    println!("Hello world")
}

#[no_mangle]
pub extern "C" fn sendstring(c_buf : *const std::ffi::c_char) {
    let c_str: &CStr = unsafe { CStr::from_ptr(c_buf) };
    let buf: &[u8] = c_str.to_bytes();
    let str_slice: &str = str::from_utf8(buf).unwrap();
    let str_buf: String = str_slice.to_owned();
    println!("Rust received a string: {}", str_buf)
}
